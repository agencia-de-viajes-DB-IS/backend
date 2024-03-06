using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.HotelsDeals.GetHotelsDeals.Queries.GetAll;

public record GetHotelsDealsQuery : IRequest<IEnumerable<HotelsDealsResponse>>;