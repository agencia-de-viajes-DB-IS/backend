
namespace TravelAgency.Application.Handlers.Agencies.RelateAgencyWithHotelDeal;

public record RelateAgencyWithHotelDealResponse(
    Guid AgencyId,
    Guid HotelDealId
);