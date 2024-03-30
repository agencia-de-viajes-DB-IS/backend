using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;

namespace TravelAgency.Api.Features.Facility;

public class GetFacilitiesEndpoint(ISender _mediator) : EndpointWithoutRequest<FacilityResponse[]>
{
    public override void Configure()
    {
        Get("/facilities");
        // AllowAnonymous();
        Permissions("ReadFacilities");
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetFacilitiesCommand();
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}