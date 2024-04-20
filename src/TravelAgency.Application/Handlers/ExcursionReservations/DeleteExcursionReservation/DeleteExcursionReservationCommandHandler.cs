using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExcursionReservations.DeleteExcursionReservation;

public class DeleteExcursionReservationCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteExcursionReservationCommand, DeleteExcursionReservationResponse>
{
    public async Task<DeleteExcursionReservationResponse> Handle(DeleteExcursionReservationCommand request, CancellationToken cancellationToken)
    {
        var excursionReservationRepo = _unitOfWork.GetRepository<ExcursionReservation>();

        var excursionReservationFilters = new Expression<Func<ExcursionReservation, bool>>[] {
            exc => exc.Id == request.Id,
            exc => exc.ReservationDate > DateTime.UtcNow
        };

        var  excursionReservationInclude = new Expression<Func<ExcursionReservation, object>>[] {
            exc => exc.Excursion
        };

        if ((await excursionReservationRepo.FindAsync(excursionReservationInclude, excursionReservationFilters)) is null)
            throw new TravelAgencyException("Excursion reservation was not found or cannot be cancelled", $"Excursion reservation with Id {request.Id} was not found", 404);

        await excursionReservationRepo.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();

        var response = new DeleteExcursionReservationResponse(request.Id);

        return response;
    }
}