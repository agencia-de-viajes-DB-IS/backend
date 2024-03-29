using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Users.AddTouristUser;

namespace TravelAgency.Api.Features.User;

public class AddTouristsUserEndpoint(ISender mediator) : Endpoint<AddUserTouristCommand, AddTouristResponse>
{
    public override void Configure()
    {
        Post("/users/tourists");
        AllowAnonymous();
        // Permissions("ReadUsers");
    }

    public override async Task HandleAsync(AddUserTouristCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}