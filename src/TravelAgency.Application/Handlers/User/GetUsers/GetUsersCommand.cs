using MediatR;
using TravelAgency.Api.Responses;

namespace TravelAgency.Application.Handlers.User.GetUsers;

public record GetUsersCommand : IRequest<IEnumerable<UserResponse>>;