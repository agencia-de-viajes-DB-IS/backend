using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.ExcursionReservations.DeleteExcursionReservation;

namespace TravelAgency.Api.Features.ExcursionReservation;

public class DeleteExcursionReservationEndpoint(ISender _mediator) : Endpoint<DeleteExcursionReservationCommand, DeleteExcursionReservationResponse>
{
    public override void Configure()
    {
        Delete("/reservation/excursion");
        AllowAnonymous();
        // Permissions("WritePackageReservation");
    }
    public override async Task HandleAsync(DeleteExcursionReservationCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}