using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationCommand : IRequest<CreateExcursionReservationResponse>
{
    public required string Airline { get; set; }
    public decimal Price { get; set; }
    public DateTime ReservationDate { get; set; }
    public Guid UserId { get; set; }
    public Guid ExcursionId { get; set; }
    public required IEnumerable<CreateTouristCommand> Tourists { get; set; }
}