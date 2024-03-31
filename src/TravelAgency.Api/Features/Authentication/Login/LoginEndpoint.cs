using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Authentication.Login;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.Authentication.Login;

public class LoginEndpoint : Endpoint<LoginQuery, AuthenticationResponse>
{
    private readonly ISender _mediator;

    public LoginEndpoint(ISender mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/auth/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(LoginQuery request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request);
        await SendAsync(result, statusCode: 200);
    }
}