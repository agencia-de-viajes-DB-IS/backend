using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDealReservations.Commands.Create
{
    public class CreateHotelDealReservationCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateHotelDealReservationCommand, CreateHotelDealReservationResponse>
    {
        public async Task<CreateHotelDealReservationResponse> Handle(CreateHotelDealReservationCommand request, CancellationToken cancellationToken)
        {
            var HotelDealReservationRepo = _unitOfWork.GetRepository<HotelDealReservation>();
            var touristRepo = _unitOfWork.GetRepository<Tourist>();

            var tourists = await touristRepo.StoreRequestTourists(request.Tourists);

            var reservation = new HotelDealReservation()
            {
                AirlineId = request.AirlineId,
                Price = request.Price,
                ReservationDate = request.ReservationDate,
                UserId = request.UserId,
                AgencyRelatedHotelDealId = request.AgencyRelatedHotelDealId,
                Tourists = tourists
            };
            await HotelDealReservationRepo.InsertAsync(reservation);
            await _unitOfWork.SaveAsync();

            var response = new CreateHotelDealReservationResponse(reservation.Id);
            return response;
        }
    }
}