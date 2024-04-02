using System.Text;
using FastEndpoints;
using MediatR;
using Stripe;
using TravelAgency.Application.Consumers.Stripe;
using TravelAgency.Application.Handlers.Airlines.GetAirlines;

namespace TravelAgency.Api.Webhooks.Stripe;

public class GetAirlinesEndpoint(IMediator mediator, IConfiguration _configuration) : Endpoint<Object>
{
    public override void Configure()
    {
        Post("/webhooks/stripe");
        AllowAnonymous();
    }
    public override async Task HandleAsync(Object input , CancellationToken ct)
    {
        var secret = _configuration["STRIPE_WEBHOOK_KEY"];
        using (var reader = new StreamReader(HttpContext.Request.Body, Encoding.UTF8))
        {
            var payload = await reader.ReadToEndAsync();
            var sigHeader = HttpContext.Request.Headers["Stripe-Signature"].ToString();
            Event eventReceived = EventUtility.ConstructEvent(
                payload, sigHeader, secret
            );
            await mediator.Publish(new StripeEventNotification(){ stripeEvent = input}, ct); 
        }
        await SendOkAsync("ok", ct);
    }
}

