using FastEndpoints;
using MediatR;
using TravelAgency.Api.Common;
using TravelAgency.Api.Requests;
using TravelAgency.Application.Handlers.Agencies.RelateAgencyWithHotelDeal;
using TravelAgency.Application.Handlers.Agencies.SplitAgencyWithHotelDeal;

namespace TravelAgency.Api.Features.Agency;

public class SplitAgencyWithHotelDeal(ISender mediator) : Endpoint<RelateAgencyWithHotelDealRequest, RelateAgencyWithHotelDealResponse>
{
    public override void Configure()
    {
        Delete("/agencies/hoteldeal");
        // AllowAnonymous();
        Permissions("WriteAgencies");
    }

    public override async Task HandleAsync(RelateAgencyWithHotelDealRequest request, CancellationToken ct)
    {
        var agencyId = User.Claims.FirstOrDefault(c => c.Type.Contains(ClaimTypes.AgencyId))?.Value;

        var command = new SplitAgencyWithHotelDealCommand(Guid.Parse(agencyId!), request.HotelDealId);
        
        var response = await mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}