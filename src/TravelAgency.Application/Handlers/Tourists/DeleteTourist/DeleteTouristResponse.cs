using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;

namespace TravelAgency.Application.Handlers.Tourists.DeleteTourist;

public record DeleteTouristResponse(
    Guid Id
) : IRequest<TouristResponse>;