using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Statistics.Queries.RecurrentTravelers;

namespace TravelAgency.Api.Features.Statistics;
public class RecurrentTravelers(ISender _mediator) : Endpoint<RecurrentTravelersQuery, RecurrentTravelersResponse>
{
    public override void Configure()
    {
        Get("/statistics/recurrentTravelers");
        AllowAnonymous();
    }
    public override async Task HandleAsync(RecurrentTravelersQuery query, CancellationToken ct)
    {
        var response = await _mediator.Send(query, ct);
        await SendOkAsync(response, ct);
    }
}