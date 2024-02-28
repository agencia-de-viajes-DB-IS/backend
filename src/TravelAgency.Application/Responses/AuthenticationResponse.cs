namespace TravelAgency.Application.Responses;

public record AuthenticationResponse(
    string Email,
    string Token
);