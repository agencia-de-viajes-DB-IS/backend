using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Excursions.CreateExcursions;

namespace TravelAgency.Api.Features.Excursion;

public class CreateExcursionEndpoint(ISender mediator) : Endpoint<CreateExcursionCommand, CreateExcursionResponse>
{
    public override void Configure()
    {
        Post("/excursions/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateExcursionCommand request, CancellationToken ct)
    {
        var response = await mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}