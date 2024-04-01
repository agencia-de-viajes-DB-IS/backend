using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.ExtendedExcursions.CreateExtendedExcursions;
using TravelAgency.Application.Handlers.ExtendedExcursions.DeleteExtendedExcursions;
using TravelAgency.Application.Handlers.ExtendedExcursions.UpdateExtendedExcursions;

namespace TravelAgency.Api.Features.ExtendedExcursion;

public class DeleteExtendedExcursionEndpoint(ISender mediator) : Endpoint<DeleteExtendedExcursionCommand, DeleteExtendedExcursionResponse>
{
    public override void Configure()
    {
        Delete("/extended/excursions");
        AllowAnonymous();
        //Permissions(Domain.Enums.Permissions.WriteExcursions.ToString());
    }

    public override async Task HandleAsync(DeleteExtendedExcursionCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}