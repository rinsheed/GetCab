using Microsoft.EntityFrameworkCore;
using Rider.Application.Contract;
using Rider.Domain.Domain;
using Rider.Infrastructure.Persistence.Configuration;

namespace Rider.Infrastructure.Persistence;

public class RiderDbContext : DbContext, IRiderDbContext
{
    public RiderDbContext(DbContextOptions<RiderDbContext> options) : base(options)
    {
        
    }

    public DbSet<RiderDetail> RiderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new RiderDetailConfiguration());
    }
}
