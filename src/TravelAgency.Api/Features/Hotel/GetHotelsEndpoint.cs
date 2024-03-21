using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Hotels.Queries.GetAll;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.Hotels;

public class GetHotelsEndpoint(ISender _mediator) : EndpointWithoutRequest<IEnumerable<HotelsResponse>>
{
    public override void Configure()
    {
        // TODO: auth this endpoint
        Get("/hotels");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetHotelsQuery();
        var response = await _mediator.Send(query, ct);
        await SendOkAsync(response, ct);
    }
}