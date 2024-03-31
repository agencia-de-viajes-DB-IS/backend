using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Users.AddUserFromBackOffice;

namespace TravelAgency.Api.Features.User;

public class AddUserFromBackOfficeEndpoint(ISender mediator) : Endpoint<AddUserFromBackOfficeCommand, AddUserFromBackOfficeResponse>
{
    public override void Configure()
    {
        Post("/backOffice/users");
        Permissions("WriteUsers");
    }

    public override async Task HandleAsync(AddUserFromBackOfficeCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}