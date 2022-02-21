using System;
using System.Diagnostics;
using Demo.WebAPI.Configurations;
using Demo.WebAPI.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;

namespace Demo.WebAPI.Extensions;

internal static class LogExtensions
{
    private const string OUTPUT_TEMPLATE = "[{Timestamp:HH:mm:ss.fffffff} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";

    public static void AddSerilog(this IConfigurationBuilder configuration)
    {
        var settings = configuration.Build();
        var logPath = settings.GetValue<string>(nameof(APIConfig.LOG_PATH));
        if(string.IsNullOrWhiteSpace(logPath))
        {
            logPath = Settings.LOG_PATH_DEFAULT;
        }

        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .Enrich.WithProperty("MachineName", Environment.MachineName)
            .WriteTo.Async(a =>
            {
                a.Console(outputTemplate: OUTPUT_TEMPLATE);
                a.File(
                    outputTemplate: OUTPUT_TEMPLATE,
                    path: logPath,
                    rollingInterval: RollingInterval.Day
                );
            })
            .CreateLogger();
    }

    public static IApplicationBuilder UseSerilog(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging(c => c.EnrichDiagnosticContext = _enrichFromRequest);
        app.UseMiddleware<RequestLogMiddleware>();

        return app;
    }

    private static void _enrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        => diagnosticContext.Set("CorrelationId", httpContext.GetCorrelationId());

    internal static string GetCorrelationId(this HttpContext httpContext)
        => Activity.Current?.Id ?? httpContext?.TraceIdentifier;
}
