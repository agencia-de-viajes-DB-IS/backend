using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.CreateAgencies;

// handler

public class CreateAgencyCommandHandler(IUnitOfWork iunitOfWork)
    : IRequestHandler<CreateAgencyCommand, CreateAgencyResponse>
{
    public async Task<CreateAgencyResponse> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
    {
        var createAgencyResponse = new CreateAgencyResponse();
        var validator = new CreateAgencyCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            createAgencyResponse.Success = false;
            createAgencyResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createAgencyResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createAgencyResponse.Success)
        {
            var agency = new Agency
            {
                Id = new Guid(),
                Name = request.Name,
                Address = request.Address,
                FaxNumber = request.FaxNumber,
                Email = request.Email
            };

            await iunitOfWork.GetRepository<Agency>().InsertAsync(agency);
            await iunitOfWork.SaveAsync();
            createAgencyResponse.Agency = new CreateAgencyDto
            (
                agency.Name,
                agency.Email
            );
        }
        return createAgencyResponse;
    }
}