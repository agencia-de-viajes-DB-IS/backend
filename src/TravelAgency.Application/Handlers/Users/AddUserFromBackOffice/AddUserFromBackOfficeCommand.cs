using MediatR;

namespace TravelAgency.Application.Handlers.Users.AddUserFromBackOffice; 

public record AddUserFromBackOfficeCommand 
(
    string FirstName, 
    string LastName,
    string Email,
    string Password,
    Guid RoleId
): IRequest<AddUserFromBackOfficeResponse>;