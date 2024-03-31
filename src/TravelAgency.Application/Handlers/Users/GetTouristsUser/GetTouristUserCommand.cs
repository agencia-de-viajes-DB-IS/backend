using MediatR;

namespace TravelAgency.Application.Handlers.Users.GetTouristsUser;


public class GetUserTouristCommand : IRequest<GetTouristDto[]> {
    public Guid UserId { get; set; }
}

