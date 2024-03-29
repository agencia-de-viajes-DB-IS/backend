namespace TravelAgency.Application.Handlers.Roles.Commands.Update;
using MediatR;
using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Enums;

public record UpdateRoleCommand(
    Guid Id, 
    string Name,
    ICollection<Permissions> Permissions
) : IRequest<UpdateRoleResponse>{}
