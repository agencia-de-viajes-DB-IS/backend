using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Hotels.Commands.Create;

namespace TravelAgency.Api.Features.Hotel;

public class CreateHotelEndpoint(ISender _mediator) : Endpoint<CreateHotelCommand, HotelResponse>
{
    public override void Configure()
    {
        Post("/hotels");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreateHotelCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}