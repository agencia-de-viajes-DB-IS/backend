namespace TravelAgency.Domain.Entities;

public class ExcursionReservation
{
    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public DateTime ReservationDate { get; set; }

    // Relational Properties
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid ExcursionId { get; set; }
    public Excursion Excursion { get; set; } = null!;
    public Guid AirlineId { get; set; }
    public Airline Airline { get; set; } = null!;
    public required ICollection<Tourist> Tourists { get; set; }
}