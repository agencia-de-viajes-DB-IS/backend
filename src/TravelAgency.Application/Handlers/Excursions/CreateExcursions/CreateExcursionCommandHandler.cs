using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Excursions.CreateExcursions;

public class CreateExcursionCommandHandler(IUnitOfWork iunitOfWork) : IRequestHandler<CreateExcursionCommand, CreateExcursionResponse>
{
    public async Task<CreateExcursionResponse> Handle(CreateExcursionCommand request, CancellationToken cancellationToken)
    {
        var createExcursionResponse = new CreateExcursionResponse();
        var validator = new CreateExcursionCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        createExcursionResponse.Success = validationResult.IsValid;
        if (!createExcursionResponse.Success) return createExcursionResponse;
        var excursion = new Excursion
        {
            Id = new Guid(),
            Location = request.Location,
            Price = request.Price,
            ArrivalDate = request.ArrivalDate,
            AgencyId = request.AgencyId
        };

        await iunitOfWork.GetRepository<Excursion>().InsertAsync(excursion);
        await iunitOfWork.SaveAsync();
        createExcursionResponse.Excursion = new CreateExcursionDto
        (
            excursion.Id,
            excursion.Location,
            excursion.Price,
            excursion.ArrivalDate
        );
        return createExcursionResponse;
    }
}