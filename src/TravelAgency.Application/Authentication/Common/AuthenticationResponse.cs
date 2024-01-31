namespace TravelAgency.Application.Authentication.Common;

public record AuthenticationResponse(
    string Email,
    string Token
);