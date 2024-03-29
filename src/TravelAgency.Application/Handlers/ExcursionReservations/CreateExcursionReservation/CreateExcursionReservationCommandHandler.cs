using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateExcursionReservationCommand, CreateExcursionReservationResponse>
{
    public async Task<CreateExcursionReservationResponse> Handle(CreateExcursionReservationCommand request, CancellationToken cancellationToken)
    {
        var excursionReservationRepo = unitOfWork.GetRepository<ExcursionReservation>();
        var touristRepo = unitOfWork.GetRepository<Tourist>();
        
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

        var guid = new Guid();
        var response = new CreateExcursionReservationResponse(new CreateExcursionReservationDto(guid));
        var user = await unitOfWork.GetRepository<User>().FindAsync(filters: new List<Expression<Func<User, bool>>> { u => u.Id == request.UserId});
        if (user is null)
        {
            response.Success = false;
            response.ValidationErrors!.Add("User not found");
        }
        var excursion = await unitOfWork.GetRepository<Excursion>().FindAsync(filters: new List<Expression<Func<Excursion, bool>>> { e => e.Id == request.ExcursionId});
        if (excursion is null)
        {
            response.Success = false;
            response.ValidationErrors!.Add("Excursion not found");
            return response;
        }
        
        if (request.ReservationDate > excursion.ArrivalDate)
        {
            response.Success = false;
            response.ValidationErrors!.Add("Reservation date must be between excursion start and end date");
            return response;
        }
        
        var reservation = new ExcursionReservation
        {
            Id = guid,
            Airline = request.Airline,
            Price = request.Price,
            ReservationDate = request.ReservationDate,
            UserId = request.UserId,
            ExcursionId = request.ExcursionId,
            Tourists = tourists
        };
        await excursionReservationRepo.InsertAsync(reservation);
        await unitOfWork.SaveAsync();
        return response;
    }
}