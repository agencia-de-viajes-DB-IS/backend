namespace TravelAgency.Domain.Entities;

public class Airline
{
    // Main Properties
    public Guid Id { get; set; }
    public required string Name { get; set; }

    // Relational Properties
    public ICollection<PackageReservation>? PackageReservations {get; set;}
    public ICollection<HotelDealReservation>? HotelDealReservations {get; set;}
    public ICollection<ExcursionReservation>? ExcursionReservations {get; set;}
}