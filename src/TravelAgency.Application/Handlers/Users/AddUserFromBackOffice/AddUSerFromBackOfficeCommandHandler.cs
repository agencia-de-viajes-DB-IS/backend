using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Users.AddUserFromBackOffice;

// GENERATE A HANDLER

public class AddUserFromBackOfficeCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddUserFromBackOfficeCommand, AddUserFromBackOfficeResponse>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<AddUserFromBackOfficeResponse> Handle(AddUserFromBackOfficeCommand request, CancellationToken cancellationToken)
    {
        var userRepo = _unitOfWork.GetRepository<User>();
        var roleRepo = _unitOfWork.GetRepository<Role>();
        var agencyRepo = _unitOfWork.GetRepository<Agency>();

        var isAlreadyCreated = await userRepo.FindAsync(filters: [
            x => x.Email == request.Email
        ]); 
        if(isAlreadyCreated is not null)
        {
            throw new TravelAgencyException("User Already created", $"The user with id {isAlreadyCreated.Id} has the same email.",400); 
        }
        var isValidRole = await roleRepo.FindAsync(filters: [
            x => x.Id == request.RoleId
        ]) ?? throw new TravelAgencyException("Role not found","", 400); 

        var isValidAgency = await agencyRepo.FindAsync(filters: [
            x => x.Id == request.AgencyId
        ]) ?? throw new TravelAgencyException("Agency not found","", 400); 

        await userRepo.InsertAsync( new User(){
            Email = request.Email,
            FirstName = request.FirstName, 
            LastName = request.LastName,
            Password = request.Password,
            RoleId = request.RoleId,
            AgencyId = request.AgencyId,
        });

        await _unitOfWork.SaveAsync();
        var newUser = await userRepo.FindAsync(filters: [
            x => x.Email == request.Email
        ]); 

        return new AddUserFromBackOfficeResponse(){
            Success = true, 
            UserId = newUser!.Id
        };
    }
}