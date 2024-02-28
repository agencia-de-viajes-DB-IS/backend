namespace TravelAgency.Domain.Entities;

public class ExcursionReservation
{
    public Guid Id { get; set; }
    public required string Airline { get; set; }
    public decimal Price { get; set; }
    public DateTime ReservationDate { get; set; }

    // Relational Properties
    public Guid UserId { get; set; }
    public required User User { get; set; }
    public Guid ExcursionId { get; set; }
    public required Excursion Excursion { get; set; }
    public required ICollection<Tourist> Tourists { get; set; }
}