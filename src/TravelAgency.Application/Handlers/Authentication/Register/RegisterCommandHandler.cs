using TravelAgency.Application.Interfaces.Authentication;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Enums;
using TravelAgency.Application.Responses;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace TravelAgency.Application.Handlers.Authentication.Register;

public class RegisterCommandHandler(IJwtTokenGenerator _jwtTokenGenerator, IUnitOfWork _unitOfWork) : IRequestHandler<RegisterCommand, AuthenticationResponse>
{
    public async Task<AuthenticationResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var userRepo = _unitOfWork.GetRepository<Domain.Entities.User>();
        var roleRepo = _unitOfWork.GetRepository<Domain.Entities.Role>(); 

        var userFilter = new Expression<Func<Domain.Entities.User, bool>>[]
        {
            u => u.Email == command.Email
        };

        if (await userRepo.FindAsync(filters: userFilter) is not null)
            throw new TravelAgencyException("Email is already registered", status: 400);

        // TODO: Use a mapper to create user
        // Create user
        Domain.Entities.Role? role = await roleRepo.FindAsync(null, filters:new Expression<Func<Domain.Entities.Role, bool>>[]
        {
            u => u.Name == "Customer"
        }) ?? throw new TravelAgencyException("Operation Error", status: 500);
        var roleId = role.Id;
        
        var user = new Domain.Entities.User()
        {
            Id = Guid.NewGuid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password,
            RoleId = roleId 
            // TODO: This can be prefixed somewhere else but here, set the right permissions
        };

        // Store user into DB
        await userRepo.InsertAsync(user);
        await _unitOfWork.SaveAsync();

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