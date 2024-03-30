using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Airlines.GetAirlines;
using TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Handlers.Users.GetUsers;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.PackageReservations.GetPackageReservations;

public class GetPackageReservationsCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetPackageReservationsCommand, GetPackageReservationsResponse[]>
{
    public async Task<GetPackageReservationsResponse[]> Handle(GetPackageReservationsCommand request, CancellationToken cancellationToken)
    {
        var packageReservationRepo = _unitOfWork.GetRepository<PackageReservation>();

        var packageReservationFilters = new Expression<Func<PackageReservation, bool>>[]
        {
            packageReservation => request.UserIdFilter == default || packageReservation.UserId == request.UserIdFilter,
            packageReservation => request.PackageIdFilter == default || packageReservation.PackageId == request.PackageIdFilter,
            packageReservation => request.AirlineIdFilter == default || packageReservation.AirlineId == request.AirlineIdFilter,
            packageReservation => request.ReservationDateFilter == default || packageReservation.ReservationDate == request.ReservationDateFilter,
        };
        
        var packageReservationIncludes = new Expression<Func<PackageReservation, object>>[]
        {
            packageReservation => packageReservation.User,
            packageReservation => packageReservation.Package,
            packageReservation => packageReservation.Airline,
            packageReservation => packageReservation.Tourists,
        };

        var response = (await packageReservationRepo.FindAllAsync(includes: packageReservationIncludes, filters: packageReservationFilters))
            .Select(packageReservation => new GetPackageReservationsResponse(
                packageReservation.Id,
                new UserResponse(
                    packageReservation.User.Id,
                    packageReservation.User.FirstName,
                    packageReservation.User.LastName,
                    packageReservation.User.Email
                ),
                new PackageResponseOnReservation(
                    packageReservation.Package.Code.ToString(),
                    packageReservation.Package.Name,
                    packageReservation.Package.Description,
                    packageReservation.Package.Price
                ),
                new AirlineResponse(
                    packageReservation.Airline.Id,
                    packageReservation.Airline.Name
                ),
                packageReservation.ReservationDate,
                packageReservation.Tourists.Select(tourist => new TouristResponse(
                    tourist.Id,
                    tourist.FirstName,
                    tourist.LastName,
                    tourist.Nationality
                )).ToArray()
            )).ToArray();
        return response;
    }
}