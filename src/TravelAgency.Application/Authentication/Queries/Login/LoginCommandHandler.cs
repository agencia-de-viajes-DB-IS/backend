using TravelAgency.Application.Authentication.Common;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Application.Interfaces.Persistence;
using MediatR;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IGenericRepository<User> _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = unitOfWork.GetRepository<User>();
    }
    public async Task<AuthenticationResponse> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        // Verify user exists
        var user = await _userRepository.FindAsync(u => u.Email == query.Email);

        if (user is null)
            throw new TravelAgencyException("Email has not been registered", status: 400);

        // Verify password
        if (query.Password != user.Password)
            throw new TravelAgencyException("Invalid password", status: 400);

        // Generate token
        // TODO: Should be automatically mapped by the repository
        var token = _jwtTokenGenerator.GenerateToken(user);

        // Create result
        var response = new AuthenticationResponse(
            user.Email,
            token
        );

        return response;
    }
}