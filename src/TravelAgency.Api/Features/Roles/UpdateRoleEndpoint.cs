using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Roles.Commands.Update;

namespace TravelAgency.Api.Features.Roles;

public class UpdateRoleEndpoint(ISender _mediator) : Endpoint<UpdateRoleCommand, UpdateRoleResponse>
{
    public override void Configure()
    {
        Put("/Roles");
        Permissions("WriteRoles"); 
    }
    public override async Task HandleAsync(UpdateRoleCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}