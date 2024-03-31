using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.ExtendedExcursions.CreateExtendedExcursions;

public class CreateExtendedExcursionCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateExtendedExcursionCommand, CreateExtendedExcursionResponse>
{
    public IUnitOfWork unitOfWork = unitOfWork;

    public async Task<CreateExtendedExcursionResponse> Handle(CreateExtendedExcursionCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateExtendedExcursionCommandValidator(unitOfWork);

        var hoteldeals = await unitOfWork.GetRepository<HotelDeal>().FindAllAsync(filters: [hd => request.HotelDealsIDs.Contains(hd.Id)]);

        await validator.ValidateAsync(request, cancellationToken);
        var excursion = new ExtendedExcursion
        {
            Id = new Guid(),
            Name = request.Name,
            Description = request.Description,
            Location = request.Location,
            Price = request.Price,
            ArrivalDate = request.ArrivalDate,
            AgencyId = request.AgencyId,
            DepartureDate = request.DepartureDate,
            HotelDeals = hoteldeals.ToList(),
        };
        await unitOfWork.GetRepository<ExtendedExcursion>().InsertAsync(excursion);
        await unitOfWork.SaveAsync();
        return new CreateExtendedExcursionResponse();
    }
}
