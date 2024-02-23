namespace TravelAgency.Domain.Entities;

public class Tourist
{
    // Main Properties
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Nationality { get; set; }

    // Relational Properties
    public required ICollection<PackageReservation> PackageReservations { get; set; }
    public required ICollection<ExcursionReservation> ExcursionReservations { get; set; }
    public required ICollection<HotelDealReservation> HotelDealReservations { get; set; }
}