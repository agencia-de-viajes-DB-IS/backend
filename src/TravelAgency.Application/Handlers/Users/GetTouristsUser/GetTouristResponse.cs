using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Users.GetTourist;

public record GetTouristDto
(
    string Id,
    string FirstName,
    string LastName,
    string Nationality
);