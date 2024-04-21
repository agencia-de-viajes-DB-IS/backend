using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Statistics.Queries.OverPricePackagesCount
{
    public class OverPricePackageCountQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<OverPricePackagesCountQuery, OverPricePackagesCountResponse>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<OverPricePackagesCountResponse> Handle(OverPricePackagesCountQuery request, CancellationToken cancellationToken)
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
            return new OverPricePackagesCountResponse(){
                Count = count
            };
        }
    }
}