using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.UpdateExtendedExcursions;

public class UpdateExtendedExcursionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateExtendedExcursionCommand, UpdateExtendedExcursionResponse>
{

    public async Task<UpdateExtendedExcursionResponse> Handle(UpdateExtendedExcursionCommand request, CancellationToken cancellationToken)
    {
        var excursion = await unitOfWork.GetRepository<ExtendedExcursion>().FindAsync(filters: new Expression<Func<ExtendedExcursion, bool>>[]
        {
            x => x.Id == request.Id
        });

        var validator = new UpdateExtendedExcursionValidator(unitOfWork);
        await validator.ValidateAsync(request, cancellationToken);

        var hotelDeals = await unitOfWork.GetRepository<HotelDeal>().FindAllAsync(filters: [x => request.HotelDealsIDs.Contains(x.Id)]);
        if (excursion != null)
        {
            excursion.Name = request.Name;
            excursion.Description = request.Description;
            excursion.Location = request.Location;
            excursion.ArrivalDate = request.ArrivalDate;
            excursion.Price = request.Price;
            excursion.HotelDeals = hotelDeals.ToList();
            await unitOfWork.GetRepository<ExtendedExcursion>().UpdateAsync(excursion);
            await unitOfWork.SaveAsync();
            return new UpdateExtendedExcursionResponse();
        }
        else
        {
            var response = new UpdateExtendedExcursionResponse
            {
                Success = false,
                Message = "Not Found on repository"
            };
            return response;
        }
    }
}