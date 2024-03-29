using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationResponse : BaseResponse
{
    public CreateExcursionReservationResponse(CreateExcursionReservationDto createExcursionReservationDto)
    {
        CreateExcursionReservationDto = createExcursionReservationDto;
    }
    public CreateExcursionReservationDto CreateExcursionReservationDto { get; set; } 
}

public record CreateExcursionReservationDto(Guid Id);