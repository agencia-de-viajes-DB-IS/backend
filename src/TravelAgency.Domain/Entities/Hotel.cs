using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Domain.Entities;

public class Hotel
{
    // Main Properties
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Address { get; set; }
    [Range(0, 5)]
    public int Category { get; set; }

    // Relational Properties
    public ICollection<HotelDeal>? Deals {get; set;}
}