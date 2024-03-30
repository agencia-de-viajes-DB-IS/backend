using TravelAgency.Application.Interfaces.Payment;
using TravelAgency.Domain.Common.Exceptions;

namespace TravelAgency.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    public async Task<PaymentResponse> CreatePayment(CreatePaymentRequest request)
    {
        double totalPrice = 0;  
        var options = new Stripe.Checkout.SessionCreateOptions
        {
            SuccessUrl = request.SuccessUrl,
            ExpiresAt =  DateTime.UtcNow.AddMinutes(35), 
            LineItems = request.Products.Select((x) =>{
                totalPrice+= x.Price; 
                return new Stripe.Checkout.SessionLineItemOptions()
                {
                    PriceData = new Stripe.Checkout.SessionLineItemPriceDataOptions()
                    {
                        Currency = request.Currency,
                        UnitAmount = (long)(x.Price * 100), 
                        ProductData = new Stripe.Checkout.SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = x.Name,
                            Description = x.Description,
                            Images = x.Images
                        } 
                    },
                    Quantity = x.Quantity 
                };
            }
            ).ToList(),
            Mode = "payment",
        };

        var service = new Stripe.Checkout.SessionService();
        Stripe.Checkout.Session checkoutSession;  
        try {
            checkoutSession = await service.CreateAsync(options);
        } catch (Exception e){
            throw new TravelAgencyException("Error when stripe service tried to create a payment link",e.Message); 
        }
        return new PaymentResponse(){
            Success = true,
            PaymentId = checkoutSession.Id,
            PaymentUrl = checkoutSession.Url
        };
    }
}