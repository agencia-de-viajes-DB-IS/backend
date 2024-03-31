using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Application.Handlers.Roles.Queries.GetAll; 
public record GetRolesResponse(
    Guid Id,
    string Name, 
    ICollection<string> Permissions 
);