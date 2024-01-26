using TravelAgency.Application.Authentication.Common;
using MediatR;

namespace TravelAgency.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
) : IRequest<AuthenticationResult>;