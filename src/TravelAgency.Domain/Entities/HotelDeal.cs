namespace TravelAgency.Domain.Entities;

public class HotelDeal
{
    // Main Properties
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required DateTime ArrivalDate { get; set; }
    public required DateTime DepartureDate { get; set; }

    // Relational Properties
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;
    public ICollection<ExtendedExcursion>? ExtendedExcursions { get; set; }
    public ICollection<AgencyRelatedHotelDeal>? AgencyRelatedHotelDeals { get; set; }
}