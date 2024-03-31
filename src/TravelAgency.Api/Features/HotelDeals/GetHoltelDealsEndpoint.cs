using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.HotelDeals.Queries.GetAll;

namespace TravelAgency.Api.Features.HotelDeals;

public class GetHotelsDealsEndpoint(ISender _mediator) : EndpointWithoutRequest<IEnumerable<HotelsDealsResponse>>
{
    public override void Configure()
    {
        // TODO: auth this endpoint
        Get("/hotelDeals");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetHotelsDealsQuery();
        var response = await _mediator.Send(query, ct);
        await SendOkAsync(response, ct);
    }
}