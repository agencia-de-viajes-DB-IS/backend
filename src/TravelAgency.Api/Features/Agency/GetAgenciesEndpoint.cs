using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Agencies.GetAgencies;

namespace TravelAgency.Api.Features.Agency;

public class GetAgenciesEndpoint(ISender mediator) : EndpointWithoutRequest<GetAgencyResponse[]>
{
    public override void Configure()
    {
        Get("/agencies");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetAgenciesCommand();
        var response = await mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}