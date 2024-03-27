namespace TravelAgency.Application.Handlers.Tourists.CreateTourist;

public record TouristResponse(
    string Id,
    string FirstName,
    string LastName,
    string Nationality
);