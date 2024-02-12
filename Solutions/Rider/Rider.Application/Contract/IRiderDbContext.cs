using Microsoft.EntityFrameworkCore;
using Rider.Domain.Domain;

namespace Rider.Application.Contract;

public interface IRiderDbContext
{
    DbSet<RiderDetail> RiderDetails { get; set; }
}
