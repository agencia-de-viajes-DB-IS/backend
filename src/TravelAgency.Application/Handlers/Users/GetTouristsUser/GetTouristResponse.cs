namespace TravelAgency.Application.Handlers.Users.GetTouristsUser;

public record GetTouristDto
(
    string Id,
    string FirstName,
    string LastName,
    string Nationality
);