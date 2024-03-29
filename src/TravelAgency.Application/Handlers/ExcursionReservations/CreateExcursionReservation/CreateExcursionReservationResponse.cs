using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationResponse(Guid Id)
    : BaseResponse
{
    	public Guid Id { get; set; } = Id;
}