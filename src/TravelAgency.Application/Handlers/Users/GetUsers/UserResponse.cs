
namespace TravelAgency.Application.Handlers.Users.GetUsers;
public record UserResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email
);