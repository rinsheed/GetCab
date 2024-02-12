using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rider.Domain.Domain;

namespace Rider.Infrastructure.Persistence.Configuration;

public class RiderDetailConfiguration : IEntityTypeConfiguration<RiderDetail>
{
    public void Configure(EntityTypeBuilder<RiderDetail> builder)
    {
        builder.Property(p => p.Name).IsRequired();

        builder.HasData(
                new RiderDetail { Id = 1, Name = "John Doe", Address = "1645, Alabama" },
                new RiderDetail { Id = 2, Name = "John Peter", Address = "1646, Alabama" },
                new RiderDetail { Id = 3, Name = "Peter Joe", Address = "1647, Alabama" },
                new RiderDetail { Id = 4, Name = "Jane Foster", Address = "1648, Alabama" },
                new RiderDetail { Id = 5, Name = "Daniel Kraig", Address = "1649, Alabama" }
            );
    }
}
