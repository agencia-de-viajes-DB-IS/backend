using MediatR;

namespace TravelAgency.Application.Handlers.Users.UpdateUser;

public record UpdateUserCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email
) : IRequest<UpdateUserResponse>;
