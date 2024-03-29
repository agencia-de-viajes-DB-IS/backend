using MediatR;
using TravelAgency.Application.Responses;

namespace TravelAgency.Application.Handlers.Users.AddTouristUser;

public class AddUserTouristCommand : IRequest<AddTouristResponse>
{
    public Guid UserId { get; set; }
    public string? TouristId { get; set; }
}

public class AddTouristResponse : BaseResponse
{
}