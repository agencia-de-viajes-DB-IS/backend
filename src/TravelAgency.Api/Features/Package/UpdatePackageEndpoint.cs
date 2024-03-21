using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Packages.CreatePackage;
using TravelAgency.Application.Handlers.Packages.GetPackages;
using TravelAgency.Application.Handlers.Packages.UpdatePackage;

namespace TravelAgency.Api.Features.Package;

public class UpdatePackageEndpoint(ISender _mediator) : Endpoint<UpdatePackageCommand, PackageResponse>
{
    public override void Configure()
    {
        Put("/packages");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    public override async Task HandleAsync(UpdatePackageCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}