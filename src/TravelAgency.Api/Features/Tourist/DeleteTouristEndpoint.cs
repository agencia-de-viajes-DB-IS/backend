using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Tourists.DeleteTourist;

namespace TravelAgency.Api.Features.Tourist;

public class DeleteTouristEndpoint(ISender _mediator) : Endpoint<DeleteTouristCommand, DeleteTouristResponse>
{
    public override void Configure()
    {
        Delete("/tourists");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    public override async Task HandleAsync(DeleteTouristCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}