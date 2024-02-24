namespace TravelAgency.Domain.Entities;

public class AgencyRelatedHotelDeal
{
    // Main Properties
    public Guid Id { get; set; }

    // Relational Properties
    public Guid AgencyId { get; set; }
    public required Agency Agency { get; set; }
    public Guid HotelDealId { get; set; }
    public required HotelDeal HotelDeal { get; set; }
}