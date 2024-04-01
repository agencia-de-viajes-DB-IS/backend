using MediatR;
using TravelAgency.Application.Consumers.Stripe;
using TravelAgency.Application.Interfaces.Payment;
using TravelAgency.Application.Interfaces.Persistence;

public class StripeEventNotificationHandler(IPaymentService paymentService)
    : INotificationHandler<StripeEventNotification>
{    
    public async Task Handle(StripeEventNotification notification, CancellationToken cancellationToken)
    {
        var response = await paymentService.HandleEvent(notification.stripeEvent,cancellationToken);
        if(!response.Success)
        {
            // TODO: we do not have an error tracking persistence, so do nothing 
        }
    }
}