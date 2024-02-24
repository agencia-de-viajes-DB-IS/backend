namespace TravelAgency.Domain.Entities;

public class PackageReservation
{
    public Guid Id { get; set; }
    public required string Airline { get; set; }
    public decimal Price { get; set; }
    public DateTime ReservationDate { get; set; }

    // Relational Properties
    public Guid AgencyId { get; set; }
    public required Agency Agency { get; set; }
    public Guid UserId { get; set; }
    public required User User { get; set; }
    public Guid PackageId { get; set; }
    public required Package Package { get; set; }
    public required ICollection<Tourist> Tourists { get; set; }
}