using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

namespace TravelAgency.Api.Features.ExcursionReservation;

public class CreateExcursionReservationEndpoint(ISender _mediator) : Endpoint<CreateExcursionReservationCommand, CreateExcursionReservationResponse>
{
    public override void Configure()
    {
        Post("/reservation/excursion");
        AllowAnonymous();
        // Permissions("WritePackageReservation");
    }
    public override async Task HandleAsync(CreateExcursionReservationCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}