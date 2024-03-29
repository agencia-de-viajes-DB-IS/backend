namespace TravelAgency.Domain.Entities;

public class Excursion
{
    // Main Properties
    public Guid Id { get; set; }

    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Location { get; set; }
    public decimal Price { get; set; }
    public required DateTime ArrivalDate { get; set; }

    // Relational Properties
    public Guid AgencyId { get; set; }
    public Agency Agency { get; set; } = null!;
    public ICollection<ExcursionReservation>? ExcursionReservations {get; set;}
}