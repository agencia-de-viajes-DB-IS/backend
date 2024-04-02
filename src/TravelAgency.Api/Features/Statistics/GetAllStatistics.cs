using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Statistics.Queries;

namespace TravelAgency.Api.Features.Statistics;

public class GetAllStatisticsEndpoint(ISender _mediator) : EndpointWithoutRequest<GetAllStatisticsResponse>
{
    public override void Configure()
    {
        // TODO: auth this endpoint
        Get("/statistics");
        // AllowAnonymous();
        Permissions("ReadStatistics"); 
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetAllStatisticsQuery();
        var response = await _mediator.Send(query, ct);
        await SendOkAsync(response, ct);
    }
}