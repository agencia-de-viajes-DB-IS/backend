using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.ExtendedExcursions.CreateExtendedExcursions;

namespace TravelAgency.Api.Features.ExtendedExcursion;

public class CreateExtendedExcursionEndpoint(ISender mediator) : Endpoint<CreateExtendedExcursionCommand, CreateExtendedExcursionResponse>
{
    public override void Configure()
    {
        Post("/extended/excursions");
        AllowAnonymous();
        //Permissions(Domain.Enums.Permissions.WriteExcursions.ToString());
    }

    public override async Task HandleAsync(CreateExtendedExcursionCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}