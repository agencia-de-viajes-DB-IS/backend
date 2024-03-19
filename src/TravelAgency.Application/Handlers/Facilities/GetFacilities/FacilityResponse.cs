using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Facilities.GetFacilities;

public class FacilityResponse : BaseResponse
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public string? Description {get; set;}
};
