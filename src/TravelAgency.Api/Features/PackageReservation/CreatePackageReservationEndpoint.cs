using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;

namespace TravelAgency.Api.Features.PackageReservation;

public class CreatePackageReservationEndpoint(ISender _mediator) : Endpoint<CreatePackageReservationCommand, PackageReservationResponse>
{
    public override void Configure()
    {
        Post("/reservation/package");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    public override async Task HandleAsync(CreatePackageReservationCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}