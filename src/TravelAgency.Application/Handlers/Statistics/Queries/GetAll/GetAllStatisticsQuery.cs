using MediatR;

namespace TravelAgency.Application.Handlers.Statistics.Queries;

public record GetAllStatisticsQuery : IRequest<GetAllStatisticsResponse>{}