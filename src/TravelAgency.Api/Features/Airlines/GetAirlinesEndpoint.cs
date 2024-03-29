using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Airlines.GetAirlines;

namespace TravelAgency.Api.Features.Agency;

public class GetAirlinesEndpoint(ISender mediator) : EndpointWithoutRequest<AirlineResponse[]>
{
    public override void Configure()
    {
        Get("/airlines");
        AllowAnonymous();
        // Permissions("ReadAirlines");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetAirlinesCommand();
        var response = await mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}