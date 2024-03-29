using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Excursions.UpdateExcursions;

namespace TravelAgency.Api.Features.Excursion;

public class UpdateExcursionsEndpoint(ISender mediator) : Endpoint<UpdateExcursionCommand, UpdateExcursionResponse>
{
    public override void Configure()
    {
        Put("/excursions");
        Permissions(Domain.Enums.Permissions.WriteExcursions.ToString());
    }
    
    public override async Task HandleAsync(UpdateExcursionCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}