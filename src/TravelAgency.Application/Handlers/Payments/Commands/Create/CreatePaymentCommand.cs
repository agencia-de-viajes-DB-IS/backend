using MediatR;
using TravelAgency.Application.Interfaces.Payment;

namespace TravelAgency.Application.Handlers.Payments.Commands.Create
{
    public record CreatePaymentCommand(
        CreatePaymentRequest paymentRequest 
    ) : IRequest<CreatePaymentResponse>;
}