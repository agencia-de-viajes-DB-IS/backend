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
        var validator = new CreateAgencyCommandValidator();

        await validator.ValidateAsync(request, cancellationToken);

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
        var createAgencyResponse = new CreateAgencyResponse
        (
            agency.Id,
            agency.Name,
            agency.Email
        );
        return createAgencyResponse;
    }
}