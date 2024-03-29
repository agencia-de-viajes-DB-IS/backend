using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Roles.Commands.Create;

namespace TravelAgency.Api.Features.Role;

public class CreateRoleEndpoint(ISender _mediator) : Endpoint<CreateRoleCommand, CreateRoleResponse>
{
    public override void Configure()
    {
        Post("/Roles");
        Permissions("WriteRoles"); 
    }
    public override async Task HandleAsync(CreateRoleCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}