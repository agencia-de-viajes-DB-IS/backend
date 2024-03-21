using MediatR;

namespace TravelAgency.Application.Handlers.Hotels.Queries.GetAll; 

public record GetHotelsQuery : IRequest<IEnumerable<HotelsResponse>>;