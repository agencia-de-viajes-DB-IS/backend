using MediatR;

namespace TravelAgency.Application.Handlers.Statistics.Queries.ExtendedWeekendExcursions;

public record ExtendedWeekendExcursionCommand() : IRequest<ExtendedWeekendExcursionResponse[]>;