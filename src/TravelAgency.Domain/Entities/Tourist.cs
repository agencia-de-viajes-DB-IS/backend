namespace TravelAgency.Domain.Entities;

public class Tourist
{
    // Main Properties
    public Guid Id { get; set; }
    public required string CI { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Nationality { get; set; }
    public bool Flag { get; set; } = true;

    // Relational Properties
    public required Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<PackageReservation> PackageReservations { get; set; } = null!;
    public ICollection<ExcursionReservation> ExcursionReservations { get; set; } = null!;
    public ICollection<HotelDealReservation> HotelDealReservations { get; set; } = null!;
}