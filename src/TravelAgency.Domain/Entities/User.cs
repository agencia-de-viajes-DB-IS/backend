namespace TravelAgency.Domain.Entities;

public class User
{
    // Main Properties
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    // Relational Properties
    public int RoleId { get; set; }
    public required Role Role { get; set; }
    public ICollection<PackageReservation>? PackageReservations {get; set;}
    public ICollection<ExcursionReservation>? ExcursionReservations {get; set;}
    public ICollection<HotelDealReservation>? HotelDealReservations {get; set;}
}