using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Tourists.UpdateTourist;

namespace TravelAgency.Api.Features.Tourist;

public class UpdateTouristEndpoint(ISender _mediator) : Endpoint<UpdateTouristCommand, UpdateTouristResponse>
{
    public override void Configure()
    {
        Put("/tourists");
        // AllowAnonymous();
        Permissions("WriteTourists");
    }
    public override async Task HandleAsync(UpdateTouristCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}