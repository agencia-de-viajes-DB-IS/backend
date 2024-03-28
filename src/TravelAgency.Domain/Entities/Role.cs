using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Enums;
namespace TravelAgency.Domain.Entities;
public class Role
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required IList<Permissions> Permissions { get; set; }
}