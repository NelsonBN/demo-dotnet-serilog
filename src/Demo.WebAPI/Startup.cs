using Demo.WebAPI.Setups;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.WebAPI;

public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseSerilog();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseRouting();
        app.UseEndpoints(endpoints
            => endpoints.MapControllers() // Mapping all controller
        );
    }
}
