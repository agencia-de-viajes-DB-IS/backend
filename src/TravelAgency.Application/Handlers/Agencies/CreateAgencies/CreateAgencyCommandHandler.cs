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
        createAgencyResponse.Success  =  validationResult.IsValid;

        if (!createAgencyResponse.Success) return createAgencyResponse;
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
            agency.Id,
            agency.Name,
            agency.Email
        );
        return createAgencyResponse;
    }
}