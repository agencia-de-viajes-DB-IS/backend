using MediatR;

namespace TravelAgency.Application.Handlers.Airlines.GetAirlines;

public record GetAirlinesCommand : IRequest<AirlineResponse[]>;