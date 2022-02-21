using System;
using Demo.WebAPI.Configurations;
using Demo.WebAPI.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace Demo.WebAPI;

public static class Program
{
    public static int Main(string[] args)
    {
        try
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            Log.Information($"[STARTING] {Settings.SERVICE_NAME}");


            CreateHostBuilder(args)
                .Build()
                .Run();


            return 0;
        }
        catch(Exception exception)
        {
            Log.Fatal(exception, "Host terminated unexpectedly");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .UseSerilog((context, services, configuration)
                => context.Configure(configuration, services)
            )
            .ConfigureWebHostDefaults(webBuilder
                => webBuilder.UseStartup<Startup>()
            );
}
