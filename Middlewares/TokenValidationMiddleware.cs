using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TokenValidationMiddleware> _logger;
    private readonly string[] _publicPaths;

    public TokenValidationMiddleware(RequestDelegate next, ILogger<TokenValidationMiddleware> logger, string[] publicPaths)
    {
        _next = next;
        _logger = logger;
        _publicPaths = publicPaths;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Skip token validation for public paths
        if (_publicPaths.Any(p => context.Request.Path.StartsWithSegments(p)))
        {
            await _next(context);
            return;
        }

        // Check if user is authenticated via JWT
        if (!context.User.Identity?.IsAuthenticated ?? true)
        {
            _logger.LogWarning("🔒 Unauthorized access attempt to {Path}", context.Request.Path);

            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                error = "Unauthorized",
                message = "Invalid or missing token.",
                path = context.Request.Path,
                method = context.Request.Method
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
            return;
        }

        await _next(context);
    }
}
