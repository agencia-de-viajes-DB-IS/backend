using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Hotels.Queries.GetAll;
using TravelAgency.Application.Handlers.Hotels.Queries.HotelsInPackages;

namespace TravelAgency.Api.Features.HotelInPackages;

public class GetHotelsInPackages(ISender _mediator) : Endpoint<GetHotelsInPackagesCommand, GetHotelsResponse[]>
{
    public override void Configure()
    {
        Get("/HotelsInPackages");
        // TODO: auth
        AllowAnonymous();
    }
    public override async Task HandleAsync(GetHotelsInPackagesCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}