using System.Net;

public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<TokenValidationMiddleware> _logger;
    private readonly string _validToken;
    private readonly string[] _publicPaths;

        /// <summary>
        /// Constructor for the <see cref="TokenValidationMiddleware"/>.
        /// </summary>
        /// <param name="next">The next middleware in the pipeline.</param>
        /// <param name="logger">The logger to write diagnostic messages to.</param>
        /// <param name="validToken">The valid token to check for.</param>
        /// <param name="publicPaths">Paths to skip token validation for.</param>
    public TokenValidationMiddleware(RequestDelegate next, ILogger<TokenValidationMiddleware> logger, string validToken, string[] publicPaths)
    {
        _next = next;
        _logger = logger;
        _validToken = validToken;
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

        var token = context.Request.Headers["Authorization"].ToString();

        if (string.IsNullOrWhiteSpace(token) || !token.StartsWith("Bearer ") || token.Substring(7).Trim() != _validToken)
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

        await _next(context); // Token is valid, continue
    }
}
