using MediatR;

namespace TravelAgency.Application.Handlers.Roles.Queries.GetAll; 

public record GetRolesQuery : IRequest<IEnumerable<GetRolesResponse>>;