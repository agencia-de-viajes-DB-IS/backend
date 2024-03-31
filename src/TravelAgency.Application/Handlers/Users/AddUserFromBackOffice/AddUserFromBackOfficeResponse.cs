using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Users.AddUserFromBackOffice; 

public class AddUserFromBackOfficeResponse : BaseResponse
{
    public Guid UserId { get; set; }
}