using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.ExtendedExcursions.GetExtendedExcursions;

namespace TravelAgency.Api.Features.ExtendedExcursion;

public class GetExtendedExcursionEndpoint(ISender mediator) : Endpoint<GetExtendedExcursionCommand, GetExtendedExcursionResponse[]>
{
    public override void Configure()
    {
        Get("/extended/excursions");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetExtendedExcursionCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}