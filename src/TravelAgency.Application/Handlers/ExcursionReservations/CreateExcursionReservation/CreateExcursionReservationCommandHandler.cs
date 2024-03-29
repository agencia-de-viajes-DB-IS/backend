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

        var touristFilter = new Expression<Func<Tourist, bool>>[]
        {
            tourist => request.TouristsIDs.Contains(tourist.Id)
        };
        var user = unitOfWork.GetRepository<User>();
        var tourists = (await touristRepo.FindAllAsync(filters: touristFilter)).ToList();
        var reservation = new ExcursionReservation
        {
            Id = new Guid(),
            Airline = request.Airline,
            Price = request.Price,
            ReservationDate = request.ReservationDate,
            UserId = request.UserId,
            ExcursionId = request.ExcursionId,
            Tourists = tourists
        };
        await excursionReservationRepo.InsertAsync(reservation);
        await unitOfWork.SaveAsync();
        var response = new CreateExcursionReservationResponse(new CreateExcursionReservationDto(reservation.Id));
        return response;
    }
}