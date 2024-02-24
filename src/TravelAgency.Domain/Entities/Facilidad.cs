namespace TravelAgency.Domain.Entities;

public class Facilidad
{
    public string Descripción { get; set; }
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    // Relational Stuff
    public required ICollection<Paquete> Paquetes { get; set; } // ok 
}