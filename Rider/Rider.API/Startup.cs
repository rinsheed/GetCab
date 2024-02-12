using Microsoft.EntityFrameworkCore;
using Rider.Application.Contract;
using Rider.Infrastructure.Persistence;

namespace Rider.API;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddDbContext<RiderDbContext>(options =>
        {
            options.UseSqlite("DataSource=:memory:");
        });
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Rider API", Version = "v1" });
        });

        services.AddTransient<IRiderDbContext, RiderDbContext>();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rider API v1");
            });
        }        

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endPoints =>
        {
            endPoints.MapControllers();
        });

        app.UseHttpsRedirection();
    }
}
