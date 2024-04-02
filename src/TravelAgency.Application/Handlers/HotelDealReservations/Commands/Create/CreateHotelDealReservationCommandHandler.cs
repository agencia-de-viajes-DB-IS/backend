using MediatR;
using TravelAgency.Application.Interfaces.Payment;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDealReservations.Commands.Create
{
    public class CreateHotelDealReservationCommandHandler(IUnitOfWork _unitOfWork, IPaymentService paymentService) : IRequestHandler<CreateHotelDealReservationCommand, CreateHotelDealReservationResponse>
    {
        public async Task<CreateHotelDealReservationResponse> Handle(CreateHotelDealReservationCommand request, CancellationToken cancellationToken)
        {
            var HotelDealReservationRepo = _unitOfWork.GetRepository<HotelDealReservation>();
            var touristRepo = _unitOfWork.GetRepository<Tourist>();

            var tourists = await _unitOfWork.GetRepository<Tourist>().FindAllAsync(filters: [x => request.TouristsGuid.Contains(x.Id) && x.Flag]);

            var reservation = new HotelDealReservation()
            {
                AirlineId = request.AirlineId,
                Price = request.Price,
                ReservationDate = request.ReservationDate,
                UserId = request.UserId,
                AgencyRelatedHotelDealId = request.AgencyRelatedHotelDealId,
                Tourists = tourists.ToArray()
            };
            await HotelDealReservationRepo.InsertAsync(reservation);
            await _unitOfWork.SaveAsync();

            var paymentResponse =  await paymentService.CreatePayment(new CreatePaymentRequest(){
                CancelUrl = " ", 
                SuccessUrl = " ",
                Products = [ new ProductData(){
                    Price = (double)request.Price,
                    Quantity = tourists.Count()
                }],
                InternalPaymentId = "Problema " //TODO: como deducir esto?,  
            }, cancellationToken);
            if(!paymentResponse.Success)
                throw new TravelAgencyException("Error when trying to create a payment","",500);
            
            var response = new CreateHotelDealReservationResponse(reservation.Id, paymentResponse.PaymentUrl);
            return response;
        }
    }
}