using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Agencies.CreateAgencies;

public class CreateAgencyResponse : BaseResponse
{
    public CreateAgencyDto Agency { get; set; }
}