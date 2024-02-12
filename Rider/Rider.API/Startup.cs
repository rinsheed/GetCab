namespace Rider.API;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Rider API", Version = "v1" });
        });
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
