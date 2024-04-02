using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Payments.Queries.GetAll;
using TravelAgency.Application.Responses;

namespace TravelAgency.Api.Features.Payments;

public class GetPaymentsEndpoint(ISender _mediator) : EndpointWithoutRequest<GetPaymentsResponse[]>
{
    public override void Configure()
    {
        // TODO: auth this endpoint
        Get("/Payments");
        AllowAnonymous();
    }
    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetPaymentsQuery();
        var response = await _mediator.Send(query, ct);
        await SendOkAsync(response, ct);
    }
}