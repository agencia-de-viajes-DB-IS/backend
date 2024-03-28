using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Authentication.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<AuthenticationResponse>;