using FastEndpoints;
using MediatR;
using TravelAgency.Application.Consumers.Stripe;
using TravelAgency.Application.Handlers.Airlines.GetAirlines;

namespace TravelAgency.Api.Webhooks.Stripe;

public class GetAirlinesEndpoint(IMediator mediator) : Endpoint<Object>
{
    public override void Configure()
    {
        Post("/webhooks/stripe");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Object input , CancellationToken ct)
    {
        await mediator.Publish(new StripeEventNotification(){ stripeEvent = input}, ct); 
        await SendOkAsync("ok", ct);
    }
}

