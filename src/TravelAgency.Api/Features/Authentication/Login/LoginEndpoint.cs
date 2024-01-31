using FastEndpoints;
using TravelAgency.Application.Authentication.Common;
using TravelAgency.Application.Authentication.Queries.Login;
using MediatR;

namespace TravelAgency.Api.Features.Authentication.Register;

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