using TravelAgency.Application.Handlers.Agencies.GetAgencies;
using TravelAgency.Application.Responses;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Application.Interfaces.Payment;

public interface IPaymentService
{
    Task<PaymentResponse> CreatePayment(CreatePaymentRequest paymentRequest, CancellationToken cancellationToken); 
    Task<BaseResponse> HandleEvent(object stripeEvent, CancellationToken cancellationToken); 
}

public class PaymentResponse : BaseResponse
{
    public required string PaymentId { get; set; }
    public required string PaymentUrl  { get; set; }    
}

public class CreatePaymentRequest
{
    public required List<ProductData> Products { get; set; }
    public string Currency { get; set; } = "usd";
    public required string InternalPaymentId { get; set; }
    public required string SuccessUrl { get; set; }
    public required string CancelUrl { get; set; }
    public PaymentType paymentType { get; set; }
}
public class ProductData 
{
    public string Name { get; set; } = "No name"; 
    private int _price;
    public required int Quantity
    {
        get { return _price; }
        set { 
            _price = (value > 0)? value : 
                throw new TravelAgencyException($"Invalid quantity for product {Name}","",400); 
            }
    }
    private double _quantity;
    public required double Price
    {
        get { return _quantity; }
        set { 
            _quantity = (value > 0)? value : 
                throw new TravelAgencyException($"Invalid price for product {Name}","",400); 
            }
    }
    
    public List<string> Images { get; set; } = []; 
    public string Description { get; set; } = "No description";
}