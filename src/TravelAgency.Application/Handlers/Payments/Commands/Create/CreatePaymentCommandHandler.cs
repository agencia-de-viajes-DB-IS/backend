using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Facilities.GetFacilities;
using TravelAgency.Application.Interfaces.Payment;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Payments.Commands.Create
{
    public class CreatePaymentCommandHandler(IUnitOfWork _unitOfWork, IPaymentService paymentService) : IRequestHandler<CreatePaymentCommand, CreatePaymentResponse>
    {
        public async Task<CreatePaymentResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            // Validate request
            var response = await paymentService.CreatePayment(request.paymentRequest,cancellationToken); 
            if(!response.Success)
            {
                throw new TravelAgencyException("Error when create payment attempted.");
            }
            return new CreatePaymentResponse(){
                Id = response.PaymentId, 
                PaymentUrl = response.PaymentUrl
            };
        }
    }
}