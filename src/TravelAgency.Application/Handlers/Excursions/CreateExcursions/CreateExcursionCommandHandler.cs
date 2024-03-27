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

        if (validationResult.Errors.Count > 0)
        {
            createExcursionResponse.Success = false;
            createExcursionResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createExcursionResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createExcursionResponse.Success)
        {
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
                excursion.Location,
                excursion.Price,
                excursion.ArrivalDate
            );
        }
        return createExcursionResponse;
    }
}