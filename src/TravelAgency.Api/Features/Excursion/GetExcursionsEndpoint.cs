using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Excursions.GetExcursions;

namespace TravelAgency.Api.Features.Excursion;

public class GetExcursionsEndpoint(ISender mediator) : Endpoint<GetExcursionsCommand, GetExcursionResponse[]>
{
    public override void Configure()
    {
        Get("/excursions");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetExcursionsCommand command, CancellationToken ct)
    {
        var response = await mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}