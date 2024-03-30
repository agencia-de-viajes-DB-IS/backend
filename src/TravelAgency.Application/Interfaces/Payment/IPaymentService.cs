using TravelAgency.Application.Responses;
using TravelAgency.Domain.Common.Exceptions;

namespace TravelAgency.Application.Interfaces.Payment;

public interface IPaymentService
{
    Task<PaymentResponse> CreatePayment(CreatePaymentRequest paymentRequest); 
}

public class PaymentResponse : BaseResponse
{
    public required string PaymentId { get; set; }
    public required string PaymentUrl  { get; set; }    
}

public class CreatePaymentRequest
{
    public required IEnumerable<ProductData> Products;
    public const string Currency = "usd";

}
public class ProductData 
{
    private double _price;
    public string Name { get; set; } = "No name"; 
    public required double Price
    {
        get { return _price; }
        set { 
            _price = (value > 0)? value : 
                throw new TravelAgencyException($"Invalid price for product {Name}","",400); 
            }
    }
    public string[] Images { get; set; } = []; 
    public string Description { get; set; } = "No description";
}