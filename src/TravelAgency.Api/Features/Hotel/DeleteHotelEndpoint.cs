using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Hotels.Commands.Delete;

namespace TravelAgency.Api.Features.Hotel;

public class DeleteHotelEndpoint(ISender _mediator) : Endpoint<DeleteHotelCommand, DeleteHotelResponse>
{
    public override void Configure()
    {
        Delete("/hotels");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(DeleteHotelCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}