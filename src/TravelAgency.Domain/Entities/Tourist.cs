namespace TravelAgency.Domain.Entities;

public class Tourist
{
    public Guid Id { get; set; }
    public string Nacionalidad { get; set; }
    public string Nombre { get; set; }
    
    // Relational Stuff
    public ICollection<ReservaExcursión>? ReservaExcursións { get; set; } // ok
    public ICollection<ReservaPaquete>? ReservaPaquetes { get; set; } // ok
    public ICollection<ReservaHospedaje>? ReservaHospedajes { get; set; } // ok
}