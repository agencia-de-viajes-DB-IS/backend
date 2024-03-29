using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Packages.CreatePackage;
using TravelAgency.Application.Handlers.Packages.GetPackages;

namespace TravelAgency.Api.Features.Package;

public class CreatePackageEndpoint(ISender _mediator) : Endpoint<CreatePackageCommand, PackageResponse>
{
    public override void Configure()
    {
        Post("/packages");
        AllowAnonymous();
        // Permissions("WritePackages");
    }
    public override async Task HandleAsync(CreatePackageCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}