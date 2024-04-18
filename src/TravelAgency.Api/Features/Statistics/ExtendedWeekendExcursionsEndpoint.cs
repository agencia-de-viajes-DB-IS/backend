using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Statistics.Queries.ExtendedWeekendExcursions;

namespace TravelAgency.Api.Features.Statistics;

public class ExtendedWeekendExcursionsEndpoint(ISender _mediator) : EndpointWithoutRequest<ExtendedWeekendExcursionResponse[]>
{
    public override void Configure()
    {
        Get("/statistics/extended");
        // AllowAnonymous();
        Permissions("ReadStatistics"); 
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new ExtendedWeekendExcursionCommand();
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}