using System.Security.Claims;
using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Users.GetTouristsUser;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.User;

public class GetTouristsUserEndpoint(ISender mediator) : EndpointWithoutRequest<GetTouristDto[]>
{
    public override void Configure()
    {
        Get("/users/tourists");
        // User most be authenticated and it does need any particular permission
    }

    public override async Task HandleAsync(CancellationToken ct)
    {        
        var userId = User.Claims.FirstOrDefault(c => c.Type.Contains(ClaimTypes.NameIdentifier))?.Value;        
        var response = await mediator.Send(new GetUserTouristCommand(){
            UserId = new Guid(userId!),
        }, ct);
        await SendOkAsync(response, ct);
    }
}