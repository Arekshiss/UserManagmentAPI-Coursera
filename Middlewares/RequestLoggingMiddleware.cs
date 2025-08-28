using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var method = context.Request.Method;
        var path = context.Request.Path;

        await _next(context); // Proceed to next middleware

        var statusCode = context.Response.StatusCode;
        string emoji = statusCode switch
        {
            >= 200 and < 300 => "✅",   // Success
            >= 400 and < 500 => "⚠️ ",  // Client error
            >= 500 => "❌",             // Server error
            _ => "ℹ️"                   // Other
        };

        string logMessage = $@"
-------------------------------
{emoji} {method} {path}
Status Code: {statusCode}
-------------------------------
";

        _logger.LogInformation(logMessage);
    }
}