using System.Collections;

namespace TravelAgency.Domain.Entities;

public class Hotel
{
    public Guid Id { get; set; }
    public string Dirección { get; set; }
    public int Categoría { get; set; }
    public string Nombre { get; set; }
    
    // Relational Stuff
    public ICollection<ReservaHospedaje>? ReservaHospedajes { get; set; } // ok
    public ICollection<Hospedaje> ? Hospedajes { get; set; } // ok
}