using TravelAgency.Domain.Enums;
namespace TravelAgency.Domain.ValueObjects;

public class Role
{
    public required string Name { get; set; }
    public required List<Permissions> Permissions { get; set; }
}