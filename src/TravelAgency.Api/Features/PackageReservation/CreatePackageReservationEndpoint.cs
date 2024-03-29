using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;

namespace TravelAgency.Api.Features.PackageReservation;

public class CreatePackageReservationEndpoint(ISender _mediator) : Endpoint<CreatePackageReservationCommand, PackageReservationResponse>
{
    public override void Configure()
    {
        Post("/reservation/package");
        AllowAnonymous();
        // Permissions("WritePackageReservation");
    }
    public override async Task HandleAsync(CreatePackageReservationCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}