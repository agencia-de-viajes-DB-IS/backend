using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;

namespace TravelAgency.Api.Features.Agency;

public class CreateAgencyEndpoint(ISender mediator) : Endpoint<CreateAgencyCommand, CreateAgencyResponse>
{
    public override void Configure()
    {
        Post("/agencies");
        Permissions(Domain.Enums.Permissions.WriteAgencies.ToString());    
    }

    public override async Task HandleAsync(CreateAgencyCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}