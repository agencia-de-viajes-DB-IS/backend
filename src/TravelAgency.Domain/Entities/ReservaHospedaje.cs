using System.Diagnostics.CodeAnalysis;

namespace TravelAgency.Domain.Entities;

public class ReservaHospedaje
{
    public Guid Id { get; set; }
    public required string Airline { get; set; }
    public decimal Precio { get; set; }
    public DateTime FechaReservación { get; set; }
    
    // ok
    public Guid IdAgencia { get; set; }
    public required Agencia Agencia { get; set; }
    
    // ok
    public Guid IdUser { get; set; }
    public required User User { get; set; }
    
    // ok
    public Guid IdHospedaje { get; set; }
    public required Hospedaje Hospedaje {get;set;}
    
    // ok
    public Guid IdHotel { get; set; }
    public required Hotel Hotel { get; set; }
    
    // ok
    public required ICollection<Tourist> Tourists { get; set; }
}