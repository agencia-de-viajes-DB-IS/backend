using MediatR;

namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public record GetAgenciesCommand : IRequest<GetAgencyResponse[]>;