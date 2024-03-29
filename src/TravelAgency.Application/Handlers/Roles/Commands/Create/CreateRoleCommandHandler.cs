using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Roles.Commands.Create;

public class CreateRoleCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateRoleCommand, CreateRoleResponse>
{
    public async Task<CreateRoleResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateRoleCommandValidator();
        await validator.ValidateAsync(request, cancellationToken);

        var RoleRepo = _unitOfWork.GetRepository<Role>();

        var s = request;  
        var Role = new Role()
        {   
            Name = request.Name,
            Permissions = [.. request.Permissions]
        };

        await RoleRepo.InsertAsync(Role);
        await _unitOfWork.SaveAsync();

        var response = new CreateRoleResponse()
        {
            Id = Role.Id
        };
        return response;
    }
}