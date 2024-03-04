using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Excursions.GetExcursions;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.Excursions;

public class GetExcursionsEndpoint(ISender _mediator) : EndpointWithoutRequest<IEnumerable<ExcursionResponse>>
{
    public override void Configure()
    {
        Get("/excursions");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetExcursionsCommand();
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}