using MediatR;

namespace TravelAgency.Application.Handlers.HotelsDeals.Queries.GetAll;

public record GetHotelsDealsQuery : IRequest<HotelsDealsResponse[]>;