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

        var tourists = new List<Tourist>();

        foreach(var requestTourist in request.Tourists)
        {
            var storedTourist = await touristRepo.FindAsync(filters: [tourist => tourist.Id == requestTourist.Id]);

            if(storedTourist is null)
            {
                var newTourist = new Tourist()
                {
                    Id = requestTourist.Id,
                    FirstName = requestTourist.FirstName,
                    LastName = requestTourist.LastName,
                    Nationality = requestTourist.Nationality
                };

                await touristRepo.InsertAsync(newTourist);
                tourists.Add(newTourist);
            }
            else
            {
                tourists.Add(storedTourist);
            }
        }

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