namespace TravelAgency.Domain.Entities;

public class Excursión
{
    public Guid Id { get; set; }
    public DateTime FechaLLegada { get; set; }
    public string Localización { get; set; }
    
    // weak entity of Agencia.
    // ok
    public Guid AgenciaId { get; set; }
    public Agencia Agencia { get; set; }
    
    public ICollection<ReservaExcursión> ReservaExcursións { get; set; } // ok
}