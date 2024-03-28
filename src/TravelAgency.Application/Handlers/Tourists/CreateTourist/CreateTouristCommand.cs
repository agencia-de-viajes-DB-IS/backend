using MediatR;

namespace TravelAgency.Application.Handlers.Tourists.CreateTourist;

public record CreateTouristCommand(
    string Id,
    string FirstName,
    string LastName,
    string Nationality
) : IRequest<TouristResponse>;