using MediatR;
namespace TravelAgency.Application.Handlers.Users.GetTourist;


public class GetUserTouristCommand : IRequest<GetTouristDto[]> {
    public Guid UserId { get; set; }
}

