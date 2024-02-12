

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rider.Application.Contract;
using Rider.Infrastructure.Persistence;

namespace Rider.Infrastructure;

public static class ServiceRegistry
{
    public static void RegisterInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<RiderDbContext>(options =>
        {
            options.UseSqlite("DataSource=:memory:", b => b.MigrationsAssembly("Rider.API"));
        });
        serviceCollection.AddScoped<IRiderDbContext>(provider => provider.GetRequiredService<RiderDbContext>());
    }
}
