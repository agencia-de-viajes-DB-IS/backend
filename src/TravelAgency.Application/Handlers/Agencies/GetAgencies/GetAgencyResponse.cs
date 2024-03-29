using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Agencies.GetAgencies;

public class GetAgencyResponse : BaseResponse
{
    public GetAgencyResponse(GetAgencyDto getAgencyDto)
    {
        GetAgencyDto = getAgencyDto;
    }

    public GetAgencyDto GetAgencyDto {
        get;
        set; }
}