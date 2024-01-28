using TravelAgency.Application.Authentication.Common;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Domain.Entities;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;

namespace TravelAgency.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if(_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return new AuthenticationResult(){
            Error = null,
            ErrorMessage = "Email has been already registered",
            Success = false
            };
        }

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
        var result = new AuthenticationData(
            user.Email,
            token
        );

        return new AuthenticationResult(){
            Data = result,
            Error = null,
            ErrorMessage = null,
            Success = true
        };
    }
}