namespace TravelAgency.Domain.Entities;

public class ReservaPaquete
{
    public Guid Id { get; set; }
    public required string Airline { get; set; }
    public decimal Price { get; set; }
    
    // ok
    public Guid AgencyId { get; set; } 
    public required Agencia Agencia { get; set; }
    
    // ok
    public Guid IdPaquete { get; set; }
    public required Paquete Paquete { get; set; }
    
    // ok
    public Guid IdUser { get; set; }
    public required User User { get; set; }
    
    // ok
    public required ICollection<Tourist> Tourists { get; set; }
}