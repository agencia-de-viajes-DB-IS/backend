namespace TravelAgency.Domain.Entities;

public class Agencia
{   
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public required string Dirección { get; set; }
    public required string Email { get; set; }
    public string Fax { get; set; }
    
    // RelationalStuff.
    public ICollection<Excursión>? Excursións { get; set; } // ok
    public ICollection<Hospedaje>? Hospedajes { get; set; } // ok
    public ICollection<ReservaHospedaje>? ReservaHospedajes { get; set; } // ok
    public ICollection<ReservaPaquete>? ReservaPaquetes { get; set; }  // ok  
}