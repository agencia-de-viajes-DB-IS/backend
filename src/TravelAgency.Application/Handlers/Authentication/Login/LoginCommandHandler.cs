using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Application.Interfaces.Persistence;
using MediatR;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;
using TravelAgency.Application.Responses;
using System.Linq.Expressions;

namespace TravelAgency.Application.Handlers.Authentication.Login;

public class LoginQueryHandler(IJwtTokenGenerator _jwtTokenGenerator, IUnitOfWork _unitOfWork) : IRequestHandler<LoginQuery, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        // Verify user exists
        var userRepo = _unitOfWork.GetRepository<Domain.Entities.User>();

        var userFilter = new Expression<Func<Domain.Entities.User, bool>>[]
        {
            u => u.Email == command.Email
        };

        var user = await userRepo.FindAsync(filters: userFilter) ?? throw new TravelAgencyException("Email has not been registered", status: 400);

        // Verify password
        if (command.Password != user.Password)
            throw new TravelAgencyException("Invalid password", status: 400);

        // Generate token
        var token = await _jwtTokenGenerator.GenerateToken(user);

        // Create result
        var response = new AuthenticationResponse(
            user.Email,
            token
        );

        return response;
    }
}