using TravelAgency.Domain.Entities;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Application.Handlers.Roles.Queries.GetAll; 
public record GetRolesResponse(
    string Name, 
    ICollection<Permissions> Permissions 
);