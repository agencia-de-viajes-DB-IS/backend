using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationCommand : IRequest<CreateExcursionReservationResponse>
{
    public required Guid AirlineId { get; set; }
    public required decimal Price { get; set; }
    public required DateTime ReservationDate { get; set; }
    public required Guid UserId { get; set; }
    public required Guid ExcursionId { get; set; }
    public required IEnumerable<CreateTouristCommand> Tourists { get; set; }
}