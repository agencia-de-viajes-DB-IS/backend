namespace TravelAgency.Domain.Entities;

public class Agency
{
    // Main Properties
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    public int FaxNumber { get; set; }
    public required string Email { get; set; }

    // Relational Properties
    public ICollection<Excursion>? Excursions {get; set;}
    public ICollection<AgencyRelatedHotelDeal>? AgencyRelatedHotelDeals { get; set; }
}