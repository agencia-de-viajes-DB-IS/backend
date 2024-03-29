using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Tourists.GetTourists;

namespace TravelAgency.Api.Features.Tourist;

public class GetTouristsEndpoint(ISender _mediator) : EndpointWithoutRequest<TouristResponse[]>
{
    public override void Configure()
    {
        Get("/tourists");
        AllowAnonymous();
        // Permissions("ReadTourists");
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetTouristsCommand();
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}