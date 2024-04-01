using MediatR;

namespace TravelAgency.Application.Consumers.Stripe
{
    public class StripeEventNotification : INotification
    { 
        public Object stripeEvent { get; set; } = null!; 
    }
}