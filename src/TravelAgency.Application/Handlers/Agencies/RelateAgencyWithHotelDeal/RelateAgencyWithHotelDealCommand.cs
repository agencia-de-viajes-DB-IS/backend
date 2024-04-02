using MediatR;

namespace TravelAgency.Application.Handlers.Agencies.RelateAgencyWithHotelDeal;

public record RelateAgencyWithHotelDealCommand(
    Guid AgencyId,
    Guid HotelDealId
) : IRequest<RelateAgencyWithHotelDealResponse>;