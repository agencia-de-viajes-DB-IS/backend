namespace TravelAgency.Domain.Entities;

public class PackageReservation
{
    public Guid Id { get; set; }
    public required string Airline { get; set; }
    public decimal Price { get; set; }
    public DateTime ReservationDate { get; set; }

    // Relational Properties
    public Guid AgencyId { get; set; }
    public Agency Agency { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid PackageId { get; set; }
    public Package Package { get; set; } = null!;
    public required ICollection<Tourist> Tourists { get; set; }
}