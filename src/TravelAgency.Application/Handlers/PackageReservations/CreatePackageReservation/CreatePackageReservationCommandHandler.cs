using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;
public class CreatePackageReservationCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreatePackageReservationCommand, CreatePackageReservationResponse>
{
    public async Task<CreatePackageReservationResponse> Handle(CreatePackageReservationCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePackageReservationCommandValidator(_unitOfWork);
        await validator.ValidateAsync(request, cancellationToken);
        
        var packageReservationRepo = _unitOfWork.GetRepository<PackageReservation>();
        var touristRepo = _unitOfWork.GetRepository<Tourist>();

        var tourists = new List<Tourist>();
        foreach (var id in request.TouristsGuid)
        {
            var tt = (await _unitOfWork.GetRepository<Tourist>().FindAsync(filters: [x => x.Id == id, x => x.Flag == true]));

            if(tt is not null)
            {
                tourists.Add(tt);
            }
        }
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

        var response = new CreatePackageReservationResponse(reservation.Id);
        return response;
    }
}