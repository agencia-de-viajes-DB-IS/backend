using MediatR;
using TravelAgency.Application.Authentication.Common;

namespace TravelAgency.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<AuthenticationResult>;