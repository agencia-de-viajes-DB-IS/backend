namespace TravelAgency.Application.Handlers.Users.GetTouristsUser;

public record GetTouristDto
(
    Guid UserId,
    Guid TouristID,
    string CI,
    string FirstName,
    string LastName,
    string Nationality
);