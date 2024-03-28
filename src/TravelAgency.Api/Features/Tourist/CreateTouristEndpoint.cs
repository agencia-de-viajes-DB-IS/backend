using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Api.Features.Tourist;

public class CreateTouristEndpoint(ISender _mediator) : Endpoint<CreateTouristCommand, TouristResponse>
{
    public override void Configure()
    {
        Post("/tourists");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreateTouristCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}