using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationResponse(Guid Id)
    : BaseResponse
{
    Guid Id { get; set; } = Id;
}