using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Domain.Entities;

public class Package
{
    // Main Properties
    [Key]
    public Guid Code { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }

    // Relational Properties
    public ICollection<Facility>? Facilities { get; set; }
    public ICollection<ExtendedExcursion>? ExtendedExcursions { get; set; }
    public ICollection<PackageReservation>? PackageReservations {get; set;}
}