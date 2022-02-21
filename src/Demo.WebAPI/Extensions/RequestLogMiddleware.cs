using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace Demo.WebAPI.Extensions;

internal class RequestLogMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLogMiddleware(RequestDelegate next)
        => _next = next;

    public Task Invoke(HttpContext context)
    {
        using(LogContext.PushProperty("CorrelationId", context.GetCorrelationId()))
        {
            return _next.Invoke(context);
        }
    }
}
