using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Demo.WebAPI.Setups;

internal class LoggerMiddleware
{
    private readonly RequestDelegate _next;

    public LoggerMiddleware(RequestDelegate next)
        => _next = next;

    public Task Invoke(HttpContext context)
    {
        using(LogContext.PushProperty("CorrelationId", context.GetCorrelationId()))
        {
            return _next.Invoke(context);
        }
    }
}
