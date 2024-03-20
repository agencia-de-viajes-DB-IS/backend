using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Packages.GetPackages;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.Package;

public class GetPackagesEndpoint(ISender _mediator) : EndpointWithoutRequest<IEnumerable<PackageResponse>>
{
    public override void Configure()
    {
        Get("/packages");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetPackagesCommand();
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}