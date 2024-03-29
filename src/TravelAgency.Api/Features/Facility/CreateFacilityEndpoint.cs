using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.CreateFacility;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Handlers.Packages.GetPackages;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.Facility;

public class CreateFacilityEndpoint(ISender _mediator) : Endpoint<CreateFacilityCommand, FacilityResponse>
{
    public override void Configure()
    {
        Post("/facilities");
        AllowAnonymous();
        // Permissions("WriteFacilities");
    }
    public override async Task HandleAsync(CreateFacilityCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}