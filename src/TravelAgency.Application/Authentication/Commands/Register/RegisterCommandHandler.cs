using TravelAgency.Application.Authentication.Common;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Domain.Entities;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;

namespace TravelAgency.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetUserByEmail(command.Email) is not null)
            throw new AgencyException("Email is already registered", status: 400);

        // TODO: Use a mapper to create user
        // Create user
        var user = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            Role = UserRoles.Client
        };

        // Store user into DB
        await _userRepository.Add(user);

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);

        // Create result
        var response = new AuthenticationResponse(
            user.Email,
            token
        );

        return response;
    }
}