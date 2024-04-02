using System.Security.Cryptography.X509Certificates;
using MediatR;
using TravelAgency.Application.Handlers.Tourists.CreateTourist;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Statistics.Queries.GetAll
{
    class GetAllStatisticsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllStatisticsQuery, GetAllStatisticsResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public async Task<GetAllStatisticsResponse> Handle(GetAllStatisticsQuery request, CancellationToken cancellationToken)
        {
            return new GetAllStatisticsResponse(){
                TotalReservationFound = await GetTotalReservationFound(), 
                MostTravelersTourists = await MostTravelers(),
                OverPricePackagesCount = await OverPricePackagesCount(), 
            };
        }

        private async Task<int> OverPricePackagesCount()
        {
            var repoPackage = _unitOfWork.GetRepository<Package>();
            var packages = await repoPackage.FindAllAsync();
            int count = 0; 
            decimal sum = 0; 
            int result = 0;
            foreach (var item in packages)
            {
                count++; 
                sum+= item.Price; 
            }
            var avg = sum/count; 
            foreach (var item in packages)
            {
                if(item.Price > avg) result+=1; 
            }
            return result; 
        }

        private async Task<decimal> GetTotalReservationFound()
        {
            var repoPackageReservation = _unitOfWork.GetRepository<PackageReservation>();
            var repoExcursionReservation = _unitOfWork.GetRepository<ExcursionReservation>();
            var repoHotelDealReservation = _unitOfWork.GetRepository<HotelDealReservation>();
        
            var excursions =  await repoExcursionReservation.FindAllAsync();
            var hotelDeals =  await repoHotelDealReservation.FindAllAsync();
            var packages =  await repoPackageReservation.FindAllAsync();

            var totalReservationFounds = 0m;
            foreach (var item in excursions)
            {
                totalReservationFounds+= item.Price; 
            }
            foreach (var item in hotelDeals)
            {
                totalReservationFounds+= item.Price; 
            }
            foreach (var item in packages)
            {
                totalReservationFounds+= item.Price; 
            }
            return totalReservationFounds; 
        }

        private async Task<TouristResponse[]> MostTravelers()
        {
            var touristRepo = _unitOfWork.GetRepository<Tourist>(); 
            var tourists = await touristRepo.FindAllAsync(
                includes: [
                    x => x.ExcursionReservations,
                    x => x.PackageReservations,
                    x => x.HotelDealReservations
                ],
                filters: [
                x => x.PackageReservations.Count > 0 || x.HotelDealReservations.Count > 0 || x.ExcursionReservations.Count > 0 
            ]);  
            return tourists.Select(x => new TouristResponse(
                TouristID: x.Id, 
                UserId: x.UserId,
                CI: x.CI, 
                FirstName: x.FirstName,
                LastName : x.LastName,
                Nationality : x.Nationality
            )).ToArray();            
        }
    }
}