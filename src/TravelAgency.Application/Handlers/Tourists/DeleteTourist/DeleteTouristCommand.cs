using MediatR;

namespace TravelAgency.Application.Handlers.Tourists.DeleteTourist;

public record DeleteTouristCommand(
    string Id
) : IRequest<DeleteTouristResponse>;