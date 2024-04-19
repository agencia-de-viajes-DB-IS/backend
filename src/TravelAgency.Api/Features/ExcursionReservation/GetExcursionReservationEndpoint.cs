using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.ExcursionReservations.GetExcursionRerservation;

namespace TravelAgency.Api.Features.ExcursionReservation;

public class GetExcursionReservationEndpoint(ISender _mediator) : Endpoint<GetExcursionReservationCommand, GetExcursionRerservationResponse[]>
{
    public override void Configure()
    {
        Get("/reservation/excursion");
        AllowAnonymous();
        // Permissions("WritePackageReservation");
    }
    public override async Task HandleAsync(GetExcursionReservationCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}