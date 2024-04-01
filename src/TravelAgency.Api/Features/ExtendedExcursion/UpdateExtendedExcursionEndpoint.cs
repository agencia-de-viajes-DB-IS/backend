using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.ExtendedExcursions.CreateExtendedExcursions;
using TravelAgency.Application.Handlers.ExtendedExcursions.UpdateExtendedExcursions;

namespace TravelAgency.Api.Features.ExtendedExcursion;

public class UpdateExtendedExcursionEndpoint(ISender mediator) : Endpoint<UpdateExtendedExcursionCommand, UpdateExtendedExcursionResponse>
{
    public override void Configure()
    {
        Put("/extended/excursions");
        AllowAnonymous();
        //Permissions(Domain.Enums.Permissions.WriteExcursions.ToString());
    }

    public override async Task HandleAsync(UpdateExtendedExcursionCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}