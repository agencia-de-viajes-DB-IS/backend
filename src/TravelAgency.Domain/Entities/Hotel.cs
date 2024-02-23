namespace TravelAgency.Domain.Entities;

public class Hotel
{
    // Main Properties
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public int Category { get; set; }

    // Relational Properties
    public ICollection<HotelDeal>? Deals {get; set;}
}