namespace TravelAgency.Domain.Entities;

public class AgencyRelatedHotelDeal
{
    // Main Properties
    public Guid Id { get; set; }

    // Relational Properties
    public Guid AgencyId { get; set; }
    public Agency Agency { get; set; } = null!;
    public Guid HotelDealId { get; set; }
    public HotelDeal HotelDeal { get; set; } = null!;
    public ICollection<HotelDealReservation>? HotelDealReservations { get; set; }
}