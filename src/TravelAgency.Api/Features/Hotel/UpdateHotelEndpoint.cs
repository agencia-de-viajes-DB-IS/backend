using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Hotels.Commands.Update;

namespace TravelAgency.Api.Features.Hotel;

public class UpdateHotelEndpoint(ISender _mediator) : Endpoint<UpdateHotelCommand, UpdateHotelResponse>
{
    public override void Configure()
    {
        Put("/hotels");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(UpdateHotelCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}