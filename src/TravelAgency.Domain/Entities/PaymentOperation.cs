using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.Entities;

public class PaymentOperation
{
    // Main Properties
    public Guid Id { get; set; }
    public required string InternalPaymentId { get; set; }
    public required string ExternalPaymentId { get; set; }
    public required string Description { get; set; }
    public required string ProductsInfoSerializedJson { get; set; }
    public PaymentStatus Status { get; set; }
    public Currency Currency {get; set;}
    public PaymentType PaymentType {get; set;}
}