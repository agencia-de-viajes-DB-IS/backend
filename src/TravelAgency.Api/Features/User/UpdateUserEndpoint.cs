using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Users.UpdateUser;

namespace TravelAgency.Api.Features.User;

public class UpdateUsersEndpoint(ISender _mediator) : Endpoint<UpdateUserCommand, UpdateUserResponse>
{
    public override void Configure()
    {
        Put("/users");
        AllowAnonymous();
        //Permissions("ReadUsers");
    }

    public override async Task HandleAsync(UpdateUserCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}