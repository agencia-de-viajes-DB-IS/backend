using MediatR;
using TravelAgency.Domain.Enums;
namespace TravelAgency.Application.Handlers.Roles.Commands.Create;

public record CreateRoleCommand(
    string Name,
    ICollection<Permissions> Permissions
) : IRequest<CreateRoleResponse>{}
