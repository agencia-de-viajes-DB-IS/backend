using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public class CreateExcursionResponse : BaseResponse
{
    public CreateExcursionDto? Excursion { get; set; }
}