using MediatR;

namespace TravelAgency.Application.Handlers.ExcursionReservations.DeleteExcursionReservation;

public record DeleteExcursionReservationCommand(
    Guid Id
) : IRequest<DeleteExcursionReservationResponse>;