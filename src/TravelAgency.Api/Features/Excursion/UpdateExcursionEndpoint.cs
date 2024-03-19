using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Excursions.GetExcursions;
using TravelAgency.Application.Handlers.Excursions.UpdateExcursions;

namespace TravelAgency.Api.Features.Excursion;

public class UpdateExcursionsEndpoint(ISender mediator) : Endpoint<UpdateExcursionCommand, UpdateExcursionResponse>
{
    public override void Configure()
    {
        Put("/excursions/update");
        // TODO: This cannot remain anonymous. Only authorized and with specified permission can access this endpoint
        AllowAnonymous();
    }
    
    public override async Task HandleAsync(UpdateExcursionCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}