namespace TravelAgency.Domain.Entities;

public class Hospedaje
{
    public Guid Id { get; set; }
    public Decimal Price { get; set; }
    public string Descripción { get; set; }
    // this is how are modeled weak entities.
    
    // ok
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public ICollection<Agencia>? Agencias { get; set; } // ok
    public ICollection<Excursión>? Excursións { get; set; } // ok
    public ICollection<ReservaHospedaje>? ReservaHospedajes { get; set; } // ok
}