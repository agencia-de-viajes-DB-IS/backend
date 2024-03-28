using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Users.GetUsers;

public record GetUsersCommand : IRequest<UserResponse[]>;