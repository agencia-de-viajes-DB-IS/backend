using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Excursions.GetExcursions;

namespace TravelAgency.Api.Features.Excursion;

public class GetExcursionsEndpoint(ISender mediator) : EndpointWithoutRequest<IEnumerable<GetExcursionResponse>>
{
    public override void Configure()
    {
        Get("/excursions");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        Permissions(Domain.Enums.Permissions.ReadExcursions.ToString());
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetExcursionsCommand();
        var response = await mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}