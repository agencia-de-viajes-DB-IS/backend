using MediatR;

namespace TravelAgency.Application.Handlers.Tourists.DeleteTourist;

public record DeleteTouristCommand(
    Guid TouristId
) : IRequest<DeleteTouristResponse>;