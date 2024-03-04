using MediatR;
using TravelAgency.Api.Responses;

namespace TravelAgency.Application.Handlers.Users.GetUsers;

public record GetUsersCommand : IRequest<IEnumerable<UserResponse>>;