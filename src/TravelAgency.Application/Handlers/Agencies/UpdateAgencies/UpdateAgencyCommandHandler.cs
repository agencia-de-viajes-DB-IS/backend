using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Agencies.CreateAgencies;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.UpdateAgencies;

public class UpdateAgencyCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateAgencyCommand, UpdateAgencyResponse>
{
    public async Task<UpdateAgencyResponse> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
    {
        var agency = await unitOfWork.GetRepository<Agency>().FindAsync(filters: new Expression<Func<Agency, bool>>[]
        {
            x => x.Id == request.Id
        });

        var validator = new UpdateAgencyCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (agency != null)
        {
            agency.Email = request.Email;
            await unitOfWork.GetRepository<Agency>().UpdateAsync(agency);
            await unitOfWork.SaveAsync();
            return new UpdateAgencyResponse();    
        }
        else
        {
            var response = new UpdateAgencyResponse
            {
                Success = false,
                Message = "Not Found on repository"
            };
            return response;
        }
    }
}