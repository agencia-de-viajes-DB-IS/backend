using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;
using TravelAgency.Application.Handlers.PackageReservations.DeletePackageReservation;

namespace TravelAgency.Api.Features.PackageReservation;

public class DeletePackageReservationEndpoint(ISender _mediator) : Endpoint<DeletePackageReservationCommand, DeletePackageReservationResponse>
{
    public override void Configure()
    {
        Delete("/reservation/package");
        AllowAnonymous();
        // Permissions("DeletePackageReservation");
    }
    public override async Task HandleAsync(DeletePackageReservationCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}