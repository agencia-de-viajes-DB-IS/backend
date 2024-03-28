using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Excursions.DeleteExcursions;

namespace TravelAgency.Api.Features.Excursion;

public class DeleteExcursionEndpoint(ISender mediator) : Endpoint<DeleteExcursionCommand, DeleteExcursionResponse>
{
    public override void Configure()
    {
        Delete("/excursions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteExcursionCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}