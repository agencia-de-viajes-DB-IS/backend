using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Users.GetUsers;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.User;

public class GetUsersEndpoint(ISender _mediator) : EndpointWithoutRequest<UserResponse[]>
{
    public override void Configure()
    {
        Get("/users");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var command = new GetUsersCommand();
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}