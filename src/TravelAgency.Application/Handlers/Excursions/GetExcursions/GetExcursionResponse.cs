using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Excursions.GetExcursions;

public class GetExcursionResponse : BaseResponse
{
    public GetExcursionResponse(GetExcursionDto getExcursionDto)
    {
        GetExcursionDto = getExcursionDto;
    }

    public GetExcursionDto GetExcursionDto { get; set; }
}
public record GetExcursionDto(
    Guid Id, 
    string Name, 
    string Description,
    string Location,
    decimal Price,
    DateTime ArrivalDate,
    ExcursionAgencyResponse Agency);

public record ExcursionAgencyResponse(
    string Name,
    string Address,
    int FaxNumber,
    string Email);