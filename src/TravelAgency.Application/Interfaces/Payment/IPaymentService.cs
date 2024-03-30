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
    public string Currency { get; set; } = "usd";
    public required string SuccessUrl { get; set; }
    public required string CancelUrl { get; set; }
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