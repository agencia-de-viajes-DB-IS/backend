using FastEndpoints;
using MediatR;
using TravelAgency.Application.Handlers.Payments.Commands.Create;

namespace TravelAgency.Api.Features.Payment;

public class CreatePaymentEndpoint(ISender _mediator) : Endpoint<CreatePaymentCommand, CreatePaymentResponse>
{
    public override void Configure()
    {
        Post("/Payments");
        AllowAnonymous();
        // Permissions("WritePayment");
    }
    public override async Task HandleAsync(CreatePaymentCommand command, CancellationToken ct)
    {
        var response = await _mediator.Send(command, ct);
        await SendOkAsync(response, ct);
    }
}