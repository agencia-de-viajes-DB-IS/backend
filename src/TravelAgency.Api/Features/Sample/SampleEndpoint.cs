using FastEndpoints;
using TravelAgency.Api.Common;

namespace TravelAgency.Api.Features.Authentication.Register;

public class SampleEndpoint : EndpointWithoutRequest<string>
{
    public override void Configure()
    {
        Get("/sample");
        // AllowAnonymous(); // Comment this line to allow authorization
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type.Contains(ClaimTypes.NameIdentifier))?.Value;
        var userName = User.Claims.FirstOrDefault(c => c.Type.Contains(ClaimTypes.GivenName))?.Value;
        var userRole = User.Claims.FirstOrDefault(c => c.Type.Contains(ClaimTypes.Role))?.Value;

        await SendAsync($"Hello {userName}! You are an authorized {userRole} user with id {userId}");
    }
}