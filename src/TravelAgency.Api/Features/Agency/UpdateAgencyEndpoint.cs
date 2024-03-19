using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Agencies.UpdateAgencies;

namespace TravelAgency.Api.Features.Agency;

public class UpdateAgencyEndpoint(ISender mediator) : Endpoint<UpdateAgencyCommand, UpdateAgencyResponse>
{
    public override void Configure()
    {
        Put("/agencies/update");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateAgencyCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}