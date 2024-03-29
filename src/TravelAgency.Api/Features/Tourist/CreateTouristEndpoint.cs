using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Api.Features.Tourist;

public class CreateTouristEndpoint(ISender _mediator) : Endpoint<CreateTouristCommand, TouristResponse>
{
    public override void Configure()
    {
        Post("/tourists");
        AllowAnonymous();
        // Permissions("WriteTourists");
    }
    public override async Task HandleAsync(CreateTouristCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}