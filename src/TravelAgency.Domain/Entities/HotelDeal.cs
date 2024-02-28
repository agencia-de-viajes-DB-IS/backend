namespace TravelAgency.Domain.Entities;

public class HotelDeal
{
    // Main Properties
    public Guid Id { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int Category { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }

    // Relational Properties
    public Guid HotelId { get; set; }
    public required Hotel Hotel { get; set; }
    public ICollection<ExtendedExcursion>? ExtendedExcursions { get; set; }
    public ICollection<AgencyRelatedHotelDeal>? AgencyRelatedHotelDeals { get; set; }
}