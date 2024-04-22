using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;
using TravelAgency.Application.Handlers.PackageReservations.GetPackageReservations;

namespace TravelAgency.Api.Features.PackageReservation;

public class GetPackageReservationsEndpoint(ISender _mediator) : Endpoint<GetPackageReservationsCommand, GetPackageReservationsResponse[]>
{
    public override void Configure()
    {
        Get("/reservation/package");
        AllowAnonymous();
        // Permissions("ReadPackageReservation");
    }
    public override async Task HandleAsync(GetPackageReservationsCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}