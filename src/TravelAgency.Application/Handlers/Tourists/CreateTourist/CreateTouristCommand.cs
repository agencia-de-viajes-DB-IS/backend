using MediatR;

namespace TravelAgency.Application.Handlers.Tourists.CreateTourist;

public record CreateTouristCommand(
    Guid UserId,
    string CI,
    string FirstName,
    string LastName,
    string Nationality
) : IRequest<TouristResponse>;