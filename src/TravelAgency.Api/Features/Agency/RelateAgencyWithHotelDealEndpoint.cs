using FastEndpoints;
using MediatR;
using TravelAgency.Api.Common;
using TravelAgency.Api.Requests;
using TravelAgency.Application.Handlers.Agencies.GetAgencies;
using TravelAgency.Application.Handlers.Agencies.RelateAgencyWithHotelDeal;

namespace TravelAgency.Api.Features.Agency;

public class RelateAgencyWithHotelDealEndpoint(ISender mediator) : Endpoint<RelateAgencyWithHotelDealRequest, RelateAgencyWithHotelDealResponse>
{
    public override void Configure()
    {
        Post("/agencies/hoteldeal");
        // AllowAnonymous();
        Permissions("WriteAgencies");
    }

    public override async Task HandleAsync(RelateAgencyWithHotelDealRequest request, CancellationToken ct)
    {
        var agencyId = User.Claims.FirstOrDefault(c => c.Type.Contains(ClaimTypes.AgencyId))?.Value;

        var command = new RelateAgencyWithHotelDealCommand(Guid.Parse(agencyId!), request.HotelDealId);
        
        var response = await mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}