using TravelAgency.Application.Responses;
namespace TravelAgency.Application.Handlers.Payments.Commands.Create
{
    public class CreatePaymentResponse : BaseResponse
    {
        public required string Id { get; set; }
        public required string PaymentUrl { get; set; }
    };
}