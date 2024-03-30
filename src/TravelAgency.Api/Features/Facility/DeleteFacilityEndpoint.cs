using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.DeleteFacility;

namespace TravelAgency.Api.Features.Facility;

public class DeleteFacilityEndpoint(ISender _mediator) : Endpoint<DeleteFacilityCommand, DeleteFacilityResponse>
{
    public override void Configure()
    {
        Delete("/facilities");
        // AllowAnonymous();
        Permissions("WriteFacilities");
    }
    public override async Task HandleAsync(DeleteFacilityCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}