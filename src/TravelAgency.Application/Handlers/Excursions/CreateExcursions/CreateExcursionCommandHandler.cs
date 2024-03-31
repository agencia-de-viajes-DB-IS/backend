using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public class CreateExcursionCommandHandler(IUnitOfWork iunitOfWork) : IRequestHandler<CreateExcursionCommand, CreateExcursionResponse>
{
    public async Task<CreateExcursionResponse> Handle(CreateExcursionCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateExcursionCommandValidator(iunitOfWork);

        await validator.ValidateAsync(request, cancellationToken);
        var excursion = new Excursion
        {
            Id = new Guid(),
            Name = request.Name,
            Description = request.Description,
            Location = request.Location,
            Price = request.Price,
            ArrivalDate = request.ArrivalDate,
            AgencyId = request.AgencyId
        };

        await iunitOfWork.GetRepository<Excursion>().InsertAsync(excursion);
        await iunitOfWork.SaveAsync(); 
        return new CreateExcursionResponse();;
    }
}