using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.HotelsDeals.GetHotelsDeals.Queries.GetAll;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.HotelsDeals;

public class GetHotelsDealsEndpoint(ISender _mediator) : EndpointWithoutRequest<IEnumerable<HotelsDealsResponse>>
{
    public override void Configure()
    {
        // TODO: auth this endpoint
        Get("/hotelsDeals");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetHotelsDealsQuery();
        var response = await _mediator.Send(query, ct);
        await SendOkAsync(response, ct);
    }
}