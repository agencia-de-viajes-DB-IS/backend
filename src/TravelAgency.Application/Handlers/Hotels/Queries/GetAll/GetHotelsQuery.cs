using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Hotels.GetHotels.Queries.GetAll;

public record GetHotelsQuery : IRequest<IEnumerable<HotelsResponse>>;