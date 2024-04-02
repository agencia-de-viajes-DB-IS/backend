using Newtonsoft.Json;
using Stripe;
using TravelAgency.Application.Interfaces.Payment;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.Responses;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;
namespace TravelAgency.Infrastructure.Services;

public class PaymentService(IUnitOfWork unitOfWork) : IPaymentService
{
    public async Task<PaymentResponse> CreatePayment(CreatePaymentRequest request, CancellationToken cancellationToken)
    {
        double totalPrice = 0;  
        var metadata = new Dictionary<string, string>(){};
        metadata.Add("InternalPaymentId",request.InternalPaymentId);  

        var options = new Stripe.Checkout.SessionCreateOptions
        {
            SuccessUrl = request.SuccessUrl,
            ExpiresAt =  DateTime.UtcNow.AddMinutes(35),
            Metadata = metadata,
            LineItems = request.Products.Select((x) =>{
                totalPrice+= x.Price; 
                return new Stripe.Checkout.SessionLineItemOptions()
                {
                    PriceData = new Stripe.Checkout.SessionLineItemPriceDataOptions()
                    {
                        Currency = request.Currency,
                        UnitAmount = (long)(x.Price*100), 
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
            checkoutSession = await service.CreateAsync(options,cancellationToken:cancellationToken);
        } catch (Exception e){
            throw new TravelAgencyException("Error when stripe service tried to create a payment link",e.Message); 
        }
        return new PaymentResponse(){
            Success = true,
            PaymentId = checkoutSession.Id,
            PaymentUrl = checkoutSession.Url
        };
    }

    public async Task<BaseResponse> HandleEvent(object stripeEvent, CancellationToken cancellationToken)
    {
        Event @event = (Event)stripeEvent;
        var response = @event.Type switch
        {
            Events.CheckoutSessionCompleted => await HandleSuccess(@event, cancellationToken), 
            Events.CheckoutSessionAsyncPaymentFailed => await HandleFail(@event, cancellationToken),
            _ => new BaseResponse(){
                Success = false 
            }
        };
        return response; 
    }

    private async Task<BaseResponse> HandleFail(Event @event, CancellationToken cancellationToken)
    {
        var checkoutSession =  (Stripe.Checkout.Session) JsonConvert.DeserializeObject(@event.Object)!; 
        var paymentOperationRepo = unitOfWork.GetRepository<PaymentOperation>(); 

        var payment = await paymentOperationRepo.FindAsync(filters: [
            x => x.InternalPaymentId == checkoutSession.Metadata["InternalPaymentId"]
        ]); 
        if (payment == null)
        {
            return new BaseResponse(){
                Success = false
            }; 
        }      
        payment.Status = PaymentStatus.Failed; 
        await paymentOperationRepo.UpdateAsync(payment);
        await unitOfWork.SaveAsync();
        
        return new BaseResponse(){
            Success = true
        };   
    }

    private async Task<BaseResponse> HandleSuccess(Event @event, CancellationToken cancellationToken)
    {
        var checkoutSession =  (Stripe.Checkout.Session) JsonConvert.DeserializeObject(@event.Object)!; 
        var paymentOperationRepo = unitOfWork.GetRepository<PaymentOperation>(); 

        var payment = await paymentOperationRepo.FindAsync(filters: [
            x => x.InternalPaymentId == checkoutSession.Metadata["InternalPaymentId"]
        ]); 
        if (payment == null)
        {
            return new BaseResponse(){
                Success = false
            }; 
        }      
        payment.Status = (checkoutSession.PaymentStatus == "paid") ? PaymentStatus.Completed : PaymentStatus.CompletedButNotPaid; 
        await paymentOperationRepo.UpdateAsync(payment);
        await unitOfWork.SaveAsync();

        return new BaseResponse(){
            Success = true
        };   
    }
}