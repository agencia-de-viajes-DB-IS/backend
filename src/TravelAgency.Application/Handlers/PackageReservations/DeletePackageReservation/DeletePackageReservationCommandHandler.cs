using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.PackageReservations.DeletePackageReservation;

public class DeletePackageReservationCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeletePackageReservationCommand, DeletePackageReservationResponse>
{
    public async Task<DeletePackageReservationResponse> Handle(DeletePackageReservationCommand request, CancellationToken cancellationToken)
    {
        var packageReservationRepo = _unitOfWork.GetRepository<PackageReservation>();

        if((await packageReservationRepo.FindAsync(filters: [packageReservation => packageReservation.Id == request.Id])) is null)
            throw new TravelAgencyException("Package reservation was not found", $"Package reservation with Id {request.Id} was not found", 404);

        await packageReservationRepo.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();
        
        var response = new DeletePackageReservationResponse(request.Id);

        return response;
    }
}