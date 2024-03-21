using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Handlers.Facilities.UpdateFacility;

namespace TravelAgency.Api.Features.Facility;

public class UpdateFacilityEndpoint(ISender _mediator) : Endpoint<UpdateFacilityCommand, FacilityResponse>
{
    public override void Configure()
    {
        Put("/facilities");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    public override async Task HandleAsync(UpdateFacilityCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}