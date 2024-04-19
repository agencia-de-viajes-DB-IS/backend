using System.Linq.Expressions;
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

        var packageReservationFilters = new Expression<Func<PackageReservation, bool>>[] {
            packageReservation => packageReservation.Id == request.Id,
            packageReservation => packageReservation.Package.ArrivalDate > DateTime.UtcNow
        };

        var packageReservationInclude = new Expression<Func<PackageReservation, object>>[] {
            packageReservation => packageReservation.Package
        };

        if ((await packageReservationRepo.FindAsync(packageReservationInclude, packageReservationFilters)) is null)
            throw new TravelAgencyException("Package reservation was not found or cannot be cancelled", $"Package reservation with Id {request.Id} was not found", 404);

        await packageReservationRepo.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();

        var response = new DeletePackageReservationResponse(request.Id);

        return response;
    }
}