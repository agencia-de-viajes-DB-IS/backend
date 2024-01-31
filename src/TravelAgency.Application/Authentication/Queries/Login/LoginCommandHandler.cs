using TravelAgency.Application.Authentication.Common;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Application.Interfaces.Persistence;
using MediatR;

namespace TravelAgency.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    public async Task<AuthenticationResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Verify user exists
        var user = await _userRepository.GetUserByEmail(query.Email);

        if (user is null)
            throw new Exception("Email has not been registered");

        // Verify password
        if (query.Password != user.Password)
            throw new Exception("Invalid password");

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