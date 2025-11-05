using System.Diagnostics;
using System.Text;

namespace UserManagement.Api.Middleware;

public class RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<RequestResponseLoggingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        _logger.LogInformation("Handling {Method} {Path}", context.Request.Method, context.Request.Path);

        await LogRequestBodyAsync(context);

        await _next(context);

        stopwatch.Stop();
        _logger.LogInformation("Handled {Method} {Path} with {StatusCode} in {Elapsed} ms",
            context.Request.Method,
            context.Request.Path,
            context.Response.StatusCode,
            stopwatch.ElapsedMilliseconds);
    }

    private async Task LogRequestBodyAsync(HttpContext context)
    {
        if (context.Request.ContentLength is null or 0)
        {
            return;
        }

        context.Request.EnableBuffering();
        using var reader = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;

        if (!string.IsNullOrWhiteSpace(body))
        {
            // Copilot hint: consider masking sensitive data before logging.
            _logger.LogDebug("Request body: {Body}", body);
        }
    }
}
