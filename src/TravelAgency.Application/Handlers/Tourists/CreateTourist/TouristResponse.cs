namespace TravelAgency.Application.Handlers.Tourists.CreateTourist;

public record TouristResponse(
    Guid UserId,
    Guid TouristID,
    string CI,
    string FirstName,
    string LastName,
    string Nationality
);