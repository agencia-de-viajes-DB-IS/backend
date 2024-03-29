using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Roles.Commands.Update;

public class UpdateRoleCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateRoleCommand, UpdateRoleResponse>
{
    public async Task<UpdateRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateRoleCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        var RoleRepo = _unitOfWork.GetRepository<Role>();
        
        var Role = (await RoleRepo.FindAllAsync(filters: [
            Role => Role.Id == request.Id
        ])).FirstOrDefault() ?? throw new TravelAgencyException("Role was not found", $"Role with Id {request.Id} was not found", 404);

        Role.Name = request.Name ?? Role.Name;
        Role.Permissions = request.Permissions.ToList() ?? Role.Permissions;
        await RoleRepo.UpdateAsync(Role);
        await _unitOfWork.SaveAsync();

        var response = new UpdateRoleResponse()
        {
            Id = Role.Id,
        };
        return response;
    }
}