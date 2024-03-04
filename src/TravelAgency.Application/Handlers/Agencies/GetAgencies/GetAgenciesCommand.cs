using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public record GetAgenciesCommand : IRequest<IEnumerable<AgencyResponse>>;