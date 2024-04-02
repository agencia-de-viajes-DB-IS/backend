using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Interfaces.Persistence;

public static class IGenericRepositoryExtension
{
    public static async Task<ICollection<Tourist>> StoreRequestTourists(this IGenericRepository<Tourist> touristRepo, IEnumerable<CreateTouristCommand> requestTourists)
    {
        var tourists = new List<Tourist>();

        foreach (var requestTourist in requestTourists)
        {
            var storedTourist = await touristRepo.FindAsync(filters: [tourist => tourist.Id == requestTourist.Id]);

            if (storedTourist is null)
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

        return tourists;
    }
    public static async Task<int> AvailableCapacity(this IGenericRepository<Package> packageRepository, IGenericRepository<PackageReservation> packageReservationRepo, Guid packageCode)
    {
        var packageReservations = await packageReservationRepo.FindAllAsync(
            includes: [
                reservation => reservation.Tourists,
                ],
            filters: [
                reservation => reservation.PackageId == packageCode]);

        var package = (await packageRepository.FindAsync(filters: [package => package.Code == packageCode])) ?? throw new TravelAgencyException(message: "Package not found", status: 404);

        var availableCapacity = package.Capacity - packageReservations.Sum(reservation => reservation.Tourists.Count);

        return availableCapacity;
    }

    public static async Task<int> AvailableCapacity(this IGenericRepository<Excursion> excursionRepository, IGenericRepository<ExcursionReservation> excursionReservationRepo, Guid excursionId)
    {
        var excursionReservations = await excursionReservationRepo.FindAllAsync(
            includes: [
                reservation => reservation.Tourists],
            filters: [
                reservation => reservation.ExcursionId == excursionId]);

        var excursion = (await excursionRepository.FindAsync(filters: [excursion => excursion.Id == excursionId])) ?? throw new TravelAgencyException(message: "Excursion not found", status: 404);

        var availableCapacity = excursion.Capacity - excursionReservations.Sum(reservation => reservation.Tourists.Count);

        return availableCapacity;
    }

    public static async Task<int> AvailableCapacity(this IGenericRepository<HotelDeal> hotelDealRepository, IGenericRepository<HotelDealReservation> hotelDealReservationRepo, Guid hotelDealId)
    {
        var packageReservations = await hotelDealReservationRepo.FindAllAsync(
            includes: [
                reservation => reservation.Tourists,
                reservation => reservation.AgencyRelatedHotelDeal
                ],
            filters: [
                reservation => reservation.AgencyRelatedHotelDeal.HotelDealId == hotelDealId]);

        var hotelDeal = (await hotelDealRepository.FindAsync(filters: [hotelDeal => hotelDeal.Id == hotelDealId])) ?? throw new TravelAgencyException(message: "Package was not found", status: 404);

        var availableCapacity = hotelDeal.Capacity - packageReservations.Sum(reservation => reservation.Tourists.Count);

        return availableCapacity;
    }
}