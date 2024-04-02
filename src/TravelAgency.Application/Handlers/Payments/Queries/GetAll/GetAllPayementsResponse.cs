using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Payments.Queries.GetAll; 
public record GetPaymentsResponse(
    Guid id,
    PaymentStatus status,
    string description,
    string externalPaymentId,
    string internalPaymentId,
    string productsInfoSerializedJson
);