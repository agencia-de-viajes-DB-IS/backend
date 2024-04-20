using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.HotelDeals.Queries.GetAll;

namespace TravelAgency.Api.Features.HotelDeals;

public class GetHotelsDealsEndpoint(ISender _mediator) : Endpoint<GetHotelsDealsQuery,IEnumerable<HotelsDealsResponse>>
{
    public override void Configure()
    {
        // TODO: auth this endpoint
        Get("/hotelDeals");
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetHotelsDealsQuery input, CancellationToken ct)
    {
        var response = await _mediator.Send(input, ct);
        await SendOkAsync(response, ct);
    }
}