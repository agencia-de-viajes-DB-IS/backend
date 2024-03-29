using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationResponse(CreateExcursionReservationDto createExcursionReservationDto)
    : BaseResponse
{
    public CreateExcursionReservationDto CreateExcursionReservationDto { get; set; } = createExcursionReservationDto;
}

public record CreateExcursionReservationDto(Guid Id);