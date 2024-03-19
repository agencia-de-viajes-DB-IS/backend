using MediatR;

namespace TravelAgency.Application.Handlers.Excursions.DeleteExcursions;

public record DeleteExcursionCommand( Guid Id) : IRequest<DeleteExcursionResponse>;