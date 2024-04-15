using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Hotels.Queries.GetAll;
using TravelAgency.Application.Handlers.Statistics.Queries.HotelsInPackages;

namespace TravelAgency.Api.Features.Statistics;

public class GetHotelsInPackages(ISender _mediator) : Endpoint<GetHotelsInPackagesCommand, GetHotelsResponse[]>
{
    public override void Configure()
    {
        Get("/statistics/HotelsInPackages");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetHotelsInPackagesCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}