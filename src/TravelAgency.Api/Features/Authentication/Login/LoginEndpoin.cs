using FastEndpoints;
using TravelAgency.Api.Contracts.Authentication;
using TravelAgency.Application.Authentication.Common;
using TravelAgency.Application.Authentication.Queries.Login;
using MediatR;

namespace TravelAgency.Api.Features.Authentication.Register;

public class LoginEndpoint : Endpoint<LoginRequest, AuthenticationResult>
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

    public override async Task HandleAsync(LoginRequest request, CancellationToken cancellationToken)
    {
        var query = new LoginQuery(
            request.Email,
            request.Password
        );

        var result = await _mediator.Send(query);

        await SendAsync(result, statusCode: 200);
    }
}