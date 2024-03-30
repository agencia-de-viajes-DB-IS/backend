using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Packages.DeletePackage;

namespace TravelAgency.Api.Features.Package;

public class DeletePackageEndpoint(ISender _mediator) : Endpoint<DeletePackageCommand, DeletePackageResponse>
{
    public override void Configure()
    {
        Delete("/packages");
        // AllowAnonymous();
        Permissions("WritePackages");
    }
    public override async Task HandleAsync(DeletePackageCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}