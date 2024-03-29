using System.Linq.Expressions;
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

        var touristFilter = new Expression<Func<Tourist, bool>>[]
        {
            tourist => request.TouristIds.Contains(tourist.Id)
        };

        var tourists = (await touristRepo.FindAllAsync(filters: touristFilter)).ToList();

        var reservation = new PackageReservation()
        {
            Airline = request.Airline,
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