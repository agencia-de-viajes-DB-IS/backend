using FastEndpoints;
using TravelAgency.Application.Authentication.Commands.Register;
using TravelAgency.Application.Authentication.Common;
using MediatR;

namespace TravelAgency.Api.Features.Authentication.Register;

public class RegisterEndpoint : Endpoint<RegisterCommand, AuthenticationResponse>
{
    private readonly ISender _mediator;

    public RegisterEndpoint(ISender mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/auth/register");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RegisterCommand request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request);
        await SendAsync(result, statusCode: 200);
    }
}