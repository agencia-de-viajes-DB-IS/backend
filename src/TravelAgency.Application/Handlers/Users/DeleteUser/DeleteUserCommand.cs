using MediatR;

namespace TravelAgency.Application.Handlers.Users.DeleteUser;

public record DeleteUserCommand(
    Guid UserId
) : IRequest<DeleteUserResponse>;
