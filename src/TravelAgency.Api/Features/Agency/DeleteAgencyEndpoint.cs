using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;
using TravelAgency.Application.Handlers.Agencies.DeleteAgencies;

namespace TravelAgency.Api.Features.Agency;

public class DeleteAgencyEndpoint(ISender mediator) : Endpoint<DeleteAgencyCommand, DeleteAgencyResponse>
{
    public override void Configure()
    {
        Delete("/agencies");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteAgencyCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}