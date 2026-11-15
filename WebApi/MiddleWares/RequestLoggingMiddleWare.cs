using System.Diagnostics;

namespace WebApi.MiddleWares;

public class RequestLoggingMiddleWare
{
    private readonly RequestDelegate _request;
    public RequestLoggingMiddleWare(RequestDelegate request)
    {
        _request = request;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        await _request(context);
        stopwatch.Stop();
        System.Console.WriteLine($"{context.Request.Method} {context.Request.Path} -> {context.Response.StatusCode} ({stopwatch.ElapsedMilliseconds} ms)");
    }
}
