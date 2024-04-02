using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Tourists.UpdateTourist;

public class UpdateTouristCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateTouristCommand, UpdateTouristResponse>
{
    public IUnitOfWork unitOfWork = unitOfWork;

    public async Task<UpdateTouristResponse> Handle(UpdateTouristCommand request, CancellationToken cancellationToken)
    {
        // Validate request
        var validator = new UpdateTouristCommandValidator(unitOfWork);
        await validator.ValidateAsync(request, cancellationToken);

        var touristRepo = unitOfWork.GetRepository<Tourist>();

        var touristFilter = new Expression<Func<Tourist, bool>>[]
        {
            tourist => tourist.Id == request.TouristId
        };

        var tourist = await touristRepo.FindAsync(filters: touristFilter);

        var reservationsRepo = unitOfWork.GetRepository<ExcursionReservation>();

        var extExcIncludes = new Expression<Func<ExcursionReservation, object>>[]
        {
            x => x.Tourists
        };
        var extExcFilter = new Expression<Func<ExcursionReservation, bool>>[]
        {
            x => x.Tourists.Any( t => t.Id == tourist!.Id)
        };

        var result1 = await reservationsRepo.FindAllAsync(extExcIncludes, extExcFilter);

        var packResIncludes = new Expression<Func<PackageReservation, object>>[]
        {
            x => x.Tourists
        };
        var packResFilter = new Expression<Func<PackageReservation, bool>>[]
        {
            x => x.Tourists.Any( t => t.Id == tourist!.Id)
        };

        var result2 = await unitOfWork.GetRepository<PackageReservation>().FindAllAsync(packResIncludes, packResFilter);

        if ( (result1 is null || !result1.Any()) && (result2 is null || !result2.Any()))
        {
            tourist!.CI = request.CI;
            tourist.FirstName = request.FirstName;
            tourist.LastName = request.LastName;
            tourist.Nationality = request.Nationality;
            await touristRepo.UpdateAsync(tourist);
            await unitOfWork.SaveAsync();
        }
        else
        {
            tourist!.Flag = false;
            await touristRepo.UpdateAsync(tourist);
            var tourist2 = new Tourist()
            {
                UserId = tourist.Id,
                CI = request.CI,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Nationality = request.Nationality
            };
            await touristRepo.InsertAsync(tourist2);
            await unitOfWork.SaveAsync();
        }
        return new UpdateTouristResponse();
    }
}