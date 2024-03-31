using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Users.GetTouristsUser;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.User;

public class GetTouristsUserEndpoint(ISender mediator) : Endpoint<GetUserTouristCommand, GetTouristDto[]>
{
    public override void Configure()
    {
        Get("/users/tourists");
        // AllowAnonymous();
        Permissions("ReadUsers");
    }

    public override async Task HandleAsync(GetUserTouristCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}