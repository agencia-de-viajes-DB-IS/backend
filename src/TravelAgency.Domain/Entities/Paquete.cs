namespace TravelAgency.Domain.Entities;

public class Paquete
{
    public Guid Id { get; set; }
    // it seems this is the standard way to model a weak
    // entity.
    public string Código { get; set; }
    public string Descripción { get; set; }
    public int Duración { get; set; }
    public decimal Price { get; set; }
    
    // Relational Stuff
    public ICollection<Facilidad>? Facilidads { get; set; } // ok
    public ICollection<ExcursiónProlongada>? ExcursiónProlongadas {get; set;} // ok
    public ICollection<ReservaPaquete>? ReservaPaquetes {get; set;} // ok
}