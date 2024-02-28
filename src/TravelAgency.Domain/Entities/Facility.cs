namespace TravelAgency.Domain.Entities;

public class Facility
{
    // Main Properties
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    // Relational Properties
    public ICollection<Package>? Packages { get; set; }
}