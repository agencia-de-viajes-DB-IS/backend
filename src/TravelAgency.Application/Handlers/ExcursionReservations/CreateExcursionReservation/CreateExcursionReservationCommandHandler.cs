using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExcursionReservations.CreateExcursionReservation;

public class CreateExcursionReservationCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateExcursionReservationCommand, CreateExcursionReservationResponse>
{
    public async Task<CreateExcursionReservationResponse> Handle(CreateExcursionReservationCommand request, CancellationToken cancellationToken)
    {
        var excursionReservationRepo = unitOfWork.GetRepository<ExcursionReservation>();
        var validator = new CreateExcursionReservationValidator(unitOfWork);
        await validator.ValidateAsync(request, cancellationToken);
        var tourists = await unitOfWork.GetRepository<Tourist>().FindAllAsync(filters: [x => request.TouristsGuids.Contains(x.Id) && x.Flag]);
        var reservation = new ExcursionReservation
        {
            Id = new Guid(),
            AirlineId = request.AirlineId,
            Price = request.Price,
            ReservationDate = request.ReservationDate,
            UserId = request.UserId,
            ExcursionId = request.ExcursionId,
            Tourists = tourists.ToList()
        };
        await excursionReservationRepo.InsertAsync(reservation);
        await unitOfWork.SaveAsync();
        return new CreateExcursionReservationResponse(reservation.Id);


    }
}