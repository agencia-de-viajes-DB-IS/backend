using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Statistics.Queries.OverPricePackagesCount;

namespace TravelAgency.Api.Features.Statistics;
public class OverPricePackagesCount(ISender _mediator) : Endpoint<OverPricePackagesCountQuery, OverPricePackagesCountResponse>
{
    public override void Configure()
    {
        Get("/statistics/overPricePackagesCount");
        AllowAnonymous();
    }
    public override async Task HandleAsync(OverPricePackagesCountQuery query, CancellationToken ct)
    {
        var response = await _mediator.Send(query, ct);
        await SendOkAsync(response, ct);
    }
}