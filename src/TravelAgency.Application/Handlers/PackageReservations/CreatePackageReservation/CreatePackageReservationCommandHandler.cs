using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;
public class CreatePackageReservationCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreatePackageReservationCommand, PackageReservationResponse>
{
    public async Task<PackageReservationResponse> Handle(CreatePackageReservationCommand request, CancellationToken cancellationToken)
    {
        var packageReservationRepo = _unitOfWork.GetRepository<PackageReservation>();
        var touristRepo = _unitOfWork.GetRepository<Tourist>();

        var tourists = await touristRepo.StoreRequestTourists(request.Tourists);

        var reservation = new PackageReservation()
        {
            AirlineId = request.AirlineId,
            Price = request.Price,
            ReservationDate = request.ReservationDate,
            UserId = request.UserId,
            PackageId = request.PackageId,
            Tourists = tourists
        };
        await packageReservationRepo.InsertAsync(reservation);
        await _unitOfWork.SaveAsync();

        var response = new PackageReservationResponse(reservation.Id);
        return response;
    }
}