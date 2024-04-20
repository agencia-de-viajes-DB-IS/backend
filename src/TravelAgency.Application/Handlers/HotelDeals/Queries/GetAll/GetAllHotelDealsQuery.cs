using MediatR;

namespace TravelAgency.Application.Handlers.HotelDeals.Queries.GetAll;

public record GetHotelsDealsQuery(
    Guid? AgencyIdFilter 
): IRequest<HotelsDealsResponse[]>;