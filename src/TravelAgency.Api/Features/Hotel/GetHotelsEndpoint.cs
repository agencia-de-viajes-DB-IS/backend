using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Hotels.Queries.GetAll;

namespace TravelAgency.Api.Features.Hotel;

public class GetHotelsEndpoint(ISender _mediator) : EndpointWithoutRequest<IEnumerable<GetHotelsResponse>>
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