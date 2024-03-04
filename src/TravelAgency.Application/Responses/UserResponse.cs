namespace TravelAgency.Application.Responses;

public record UserResponse(
    string FirstName,
    string LastName,
    string Email
);