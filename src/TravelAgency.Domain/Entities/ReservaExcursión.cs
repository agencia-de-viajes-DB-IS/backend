namespace TravelAgency.Domain.Entities;

public class ReservaExcursión
{
    public Guid Id { get; set; }
    public required string CompañíaÁerea { get; set; }
    public decimal Price { get; set; }
    
    // ok
    public Guid UserId { get; set; } 
    public required User User { get; set; } 
    
    // ok
    public Guid ExcursionId { get; set; }
    public required Excursión Excursion { get; set; }
    
    // Relational Stuff
    public required ICollection<Tourist> Tourists { get; set; } // ok.
}