using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;

namespace TravelAgency.Api.Features.Facility;

public class GetFacilitiesEndpoint(ISender _mediator) : EndpointWithoutRequest<FacilityResponse[]>
{
    public override void Configure()
    {
        Get("/facilities");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetFacilitiesCommand();
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}