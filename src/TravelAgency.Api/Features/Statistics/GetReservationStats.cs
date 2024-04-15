using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Statistics.Queries.ReservationStats;

namespace TravelAgency.Api.Features.Statistics;

public class GetReservationsStatsEndpoint(ISender _mediator) : EndpointWithoutRequest<AgencyDto[]>
{
    public override void Configure()
    {
        Get("/ReservationStats");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetReservationStatsCommand();
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct );
    }
}