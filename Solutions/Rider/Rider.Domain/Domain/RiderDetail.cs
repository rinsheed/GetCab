using System.ComponentModel.DataAnnotations;

namespace Rider.Domain.Domain;

public class RiderDetail
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
}
