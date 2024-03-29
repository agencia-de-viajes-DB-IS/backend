namespace TravelAgency.Domain.Entities;

public class Tourist
{
    // Main Properties
    public required string Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Nationality { get; set; }

    // Relational Properties
    public ICollection<User>? Users { get; set; }
    public ICollection<PackageReservation> PackageReservations { get; set; } = null!;
    public ICollection<ExcursionReservation> ExcursionReservations { get; set; } = null!;
    public ICollection<HotelDealReservation> HotelDealReservations { get; set; } = null!;
}