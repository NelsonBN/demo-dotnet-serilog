using System;
using Demo.WebAPI.Configurations;
using Demo.WebAPI.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Demo.WebAPI;

public static class Program
{
    public static int Main(string[] args)
    {
        try
        {
            var hostBuilder = CreateHostBuilder(args).Build();

            Log.Information($"[STARTING] {Settings.SERVICE_NAME}");

            hostBuilder.Run();

            return 0;
        }
        catch(Exception ex)
        {
            Log.Fatal(ex, "The host had an unexpected error");

            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration((hostingContext, config)
                    => config.AddSerilog()
                );
                webBuilder.UseStartup<Startup>();
            });
}
