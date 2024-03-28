using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Excursions.UpdateExcursions;

public class UpdateExcursionCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateExcursionCommand, UpdateExcursionResponse>
{
    public async Task<UpdateExcursionResponse> Handle(UpdateExcursionCommand request, CancellationToken cancellationToken)
    {
        var excursion = await unitOfWork.GetRepository<Excursion>().FindAsync(filters: new Expression<Func<Excursion, bool>>[]
        {
            x => x.Id == request.Id
        });

        var validator = new UpdateExcursionCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        if (excursion != null)
        {
            excursion.Location = request.Location;
            excursion.ArrivalDate = request.ArrivalDate;
            excursion.Price = request.Price;
            await unitOfWork.GetRepository<Excursion>().UpdateAsync(excursion);
            await unitOfWork.SaveAsync();
            return new UpdateExcursionResponse();    
        }
        else
        {
            var response = new UpdateExcursionResponse
            {
                Success = false,
                Message = "Not Found on repository"
            };
            return response;
        }
    }
}