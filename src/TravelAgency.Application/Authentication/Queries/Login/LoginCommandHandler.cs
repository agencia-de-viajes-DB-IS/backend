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
        var user = await _userRepository.GetUserByEmail(query.Email);
        
        if(user is null)
        {
            return new AuthenticationResult(){
                ErrorMessage = $"User not found with email {query.Email}.",
                Success = false  
            };
        }
        // Verify password
        if(query.Password != user.Password)
        {
            return new AuthenticationResult(){
                ErrorMessage = $"Password did not match, provided password: {query.Password}.",
                Success = false  
            };
        }

        // Generate token
        var token = _jwtTokenGenerator.GenerateToken(user);

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