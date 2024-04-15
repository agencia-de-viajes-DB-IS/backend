using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Hotels.Queries.GetAll;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Statistics.Queries.HotelsInPackages;

public class GetHotelsInPackagesHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetHotelsInPackagesCommand, GetHotelsResponse[]>
{

    public async Task<GetHotelsResponse[]> Handle(GetHotelsInPackagesCommand request, CancellationToken cancellationToken)
    {
        var packagesRepo = unitOfWork.GetRepository<Package>();

        var extendedExcursionsRepo = unitOfWork.GetRepository<ExtendedExcursion>();

        var packagesIncludes = new List<Expression<Func<Package, object>>>{
            x => x.ExtendedExcursions!
        };

        var excursionIncludes = new List<Expression<Func<ExtendedExcursion, object>>>{
            x => x.HotelDeals!
        };


        List<Guid> HotelsId = [];
        var packages = (await packagesRepo.FindAllAsync(packagesIncludes)).ToList();

        foreach (var pk in packages)
        {
            foreach (var ex in pk.ExtendedExcursions!)
            {
                var exx = await extendedExcursionsRepo.FindAsync(
                    includes:
                        [x => x.HotelDeals],
                    filters:
                        [x => x.Id == ex.Id]);
                foreach (var hd in exx!.HotelDeals!)
                {
                    HotelsId.Add(hd.HotelId);
                }
            }
        }
        var hotelsRepo = unitOfWork.GetRepository<Hotel>();
        var hotels = await hotelsRepo.FindAllAsync(
            includes:
                [x => x.Deals!],
            filters:
                [x => HotelsId.Contains(x.Id)]);

        return hotels.Select(x => new GetHotelsResponse(x.Name, x.Address, x.Deals, x.Category, x.Id)).ToArray();
    }
}