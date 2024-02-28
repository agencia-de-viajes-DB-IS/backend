using TravelAgency.Application.Interfaces.Authentication;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Enums;
using TravelAgency.Application.Responses;
using System.Linq.Expressions;

namespace TravelAgency.Application.Handlers.Authentication.Register;

public class RegisterCommandHandler(IJwtTokenGenerator _jwtTokenGenerator, IUnitOfWork _unitOfWork) : IRequestHandler<RegisterCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userRepo = _unitOfWork.GetRepository<Domain.Entities.User>();

        var userFilter = new Expression<Func<Domain.Entities.User, bool>>[]
        {
            u => u.Email == command.Email
        };

        if (await userRepo.FindAsync(filters: userFilter) is not null)
            throw new TravelAgencyException("Email is already registered", status: 400);

        // TODO: Use a mapper to create user
        // Create user
        var user = new Domain.Entities.User()
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            // TODO: This can be prefixed somewhere else but here, set the right permissions
            Role = new Domain.ValueObjects.Role{
                Name = "Regular",
                Permissions = new List<Permissions> {
                    Permissions.ReadUsers,
                    Permissions.WriteUsers
                }
            }
        };

        // Store user into DB
        await userRepo.InsertAsync(user);
        await _unitOfWork.SaveAsync();

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