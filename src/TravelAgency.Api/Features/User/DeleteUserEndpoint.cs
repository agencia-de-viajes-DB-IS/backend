using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Users.DeleteUser;

namespace TravelAgency.Api.Features.User;

public class DeleteUserEndpoint(ISender _mediator) : Endpoint<DeleteUserCommand, DeleteUserResponse>
{
    public override void Configure()
    {
        Delete("/users");
        AllowAnonymous();
        //Permissions("ReadUsers");
    }

    public override async Task HandleAsync(DeleteUserCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}