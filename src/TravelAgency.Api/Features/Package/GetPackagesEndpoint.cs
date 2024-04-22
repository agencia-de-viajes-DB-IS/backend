using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Packages.GetPackages;

namespace TravelAgency.Api.Features.Package;

public class GetPackagesEndpoint(ISender _mediator) : Endpoint<GetPackagesCommand, GetPackageResponse[]>
{
    public override void Configure()
    {
        Get("/packages");
        AllowAnonymous();
        // Permissions("ReadPackages");
    }
    public override async Task HandleAsync(GetPackagesCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}