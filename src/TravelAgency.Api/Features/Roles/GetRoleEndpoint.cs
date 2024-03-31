using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Roles.Queries.GetAll;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.Roles;

public class GetRolesEndpoint(ISender _mediator) : EndpointWithoutRequest<GetRolesResponse[]>
{
    public override void Configure()
    {
        // TODO: auth this endpoint
        Get("/Roles");
        Permissions("ReadRoles"); 
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetRolesQuery();
        var response = await _mediator.Send(query, ct);
        await SendOkAsync(response, ct);
    }
}