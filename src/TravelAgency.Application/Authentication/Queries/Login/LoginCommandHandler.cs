using TravelAgency.Application.Authentication.Common;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Application.Interfaces.Persistence;
using MediatR;

namespace TravelAgency.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Verify user exists
        var user = _userRepository.GetUserByEmail(query.Email) ?? throw new Exception("Email was not found");

        // Verify password
        if(query.Password != user.Password)
            throw new Exception("Incorrect password");

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);

        await Task.CompletedTask;

        // Create result
        var result = new AuthenticationData(
            user.Email,
            token
        );

        return new AuthenticationResult(){
            Data =  result,
            Error = null,
            ErrorMessage = null,
            Success = true  
        };
    }
}