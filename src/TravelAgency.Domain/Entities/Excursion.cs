namespace TravelAgency.Domain.Entities;

public class Excursion
{
    // Main Properties
    public Guid Id { get; set; }
    public required string Location { get; set; }
    public decimal Price { get; set; }
    public DateTime ArrivalDate { get; set; }

    // Relational Properties
    public Guid AgencyId { get; set; }
    public required Agency Agency { get; set; }
    public ICollection<ExcursionReservation>? ExcursionReservations {get; set;}
}