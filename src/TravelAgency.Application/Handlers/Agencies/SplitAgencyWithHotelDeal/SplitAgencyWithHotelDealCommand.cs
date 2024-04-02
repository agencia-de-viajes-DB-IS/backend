using MediatR;
using TravelAgency.Application.Handlers.Agencies.RelateAgencyWithHotelDeal;

namespace TravelAgency.Application.Handlers.Agencies.SplitAgencyWithHotelDeal;

public record SplitAgencyWithHotelDealCommand(
    Guid AgencyId,
    Guid HotelDealId
) : IRequest<RelateAgencyWithHotelDealResponse>;