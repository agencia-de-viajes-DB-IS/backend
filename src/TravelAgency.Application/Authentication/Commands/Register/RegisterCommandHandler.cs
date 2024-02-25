using TravelAgency.Application.Authentication.Common;
using TravelAgency.Application.Interfaces.Authentication;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IGenericRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
        _userRepository = _unitOfWork.GetRepository<User>();
    }

    public async Task<AuthenticationResponse> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await _userRepository.FindAsync(u => u.Email == command.Email) is not null)
            throw new TravelAgencyException("Email is already registered", status: 400);

        // TODO: Use a mapper to create user
        // Create user
        var user = new User()
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
        await _userRepository.InsertAsync(user);
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