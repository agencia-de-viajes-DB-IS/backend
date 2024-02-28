namespace TravelAgency.Api.Responses;

public record UserResponse(
    string FirstName,
    string LastName,
    string Email
);