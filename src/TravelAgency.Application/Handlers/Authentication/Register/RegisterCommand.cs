using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Authentication.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<AuthenticationResponse>;