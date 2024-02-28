namespace TravelAgency.Domain.Entities;

public class ExtendedExcursion : Excursion
{
    // Main Properties
    public DateTime DepartureDate {get; set;}

    // Relational Properties
    public ICollection<Package>? Packages { get; set; }
    public required ICollection<HotelDeal> HotelDeals { get; set; }
}