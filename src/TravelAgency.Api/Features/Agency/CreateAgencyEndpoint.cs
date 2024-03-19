using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;

namespace TravelAgency.Api.Features.Agency.Commands;

public class CreateAgencyEndpoint : Endpoint<CreateAgencyCommand, CreateAgencyResponse>
{
    private readonly ISender _mediator;

    public CreateAgencyEndpoint(ISender mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post("/agencies/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateAgencyCommand request, CancellationToken ct)
    {
        var response = await _mediator.Send(request, ct);
        await SendOkAsync(response, ct);
    }
}