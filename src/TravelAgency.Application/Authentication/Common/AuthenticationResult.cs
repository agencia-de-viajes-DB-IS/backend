namespace TravelAgency.Application.Authentication.Common;

public class AuthenticationResult : ICommonResponse<AuthenticationData>
{
    public string? ErrorMessage {get; set;}
    public AuthenticationData? Data {get; set;}
    public bool Success {get; set;}
    public object? Error {get; set;}
}
public record AuthenticationData(
    string Email,
    string Token
);