
namespace TravelAgency.Application.Handlers.Users.GetUsers;
public record UserResponse(
    string FirstName,
    string LastName,
    string Email
);