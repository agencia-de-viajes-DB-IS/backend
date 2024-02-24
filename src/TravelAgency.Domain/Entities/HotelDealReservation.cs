namespace TravelAgency.Domain.Entities;

public class HotelDealReservation
{
    // Main Properties
    public Guid Id { get; set; }
    public required string Airline { get; set; }
    public decimal Price { get; set; }
    public DateTime ReservationDate { get; set; }

    // Relational Properties
    public Guid UserId { get; set; }
    public required User User { get; set; }
    public Guid AgencyRelatedHotelDealId { get; set; }
    public required AgencyRelatedHotelDeal AgencyRelatedHotelDeal { get; set; }
    public required ICollection<Tourist> Tourists { get; set; }
}