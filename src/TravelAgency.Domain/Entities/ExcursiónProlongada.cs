namespace TravelAgency.Domain.Entities;

public class ExcursiónProlongada : Excursión
{
    // Main Properties
    public DateTime DepartureDate {get; set;}
    // Relational Properties
    public ICollection<Paquete>? Paquetes { get; set; } // ok
    public required ICollection<Hospedaje> Hospedajes { get; set; } // ok
}