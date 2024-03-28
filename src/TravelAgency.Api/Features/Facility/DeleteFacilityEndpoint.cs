using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.DeleteFacility;

namespace TravelAgency.Api.Features.Facility;

public class DeleteFacilityEndpoint(ISender _mediator) : Endpoint<DeleteFacilityCommand, DeleteFacilityResponse>
{
    public override void Configure()
    {
        Delete("/facilities");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    public override async Task HandleAsync(DeleteFacilityCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}