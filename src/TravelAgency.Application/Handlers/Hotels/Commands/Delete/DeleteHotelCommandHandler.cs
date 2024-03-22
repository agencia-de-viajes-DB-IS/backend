using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Hotels.Commands.Delete;

public class DeleteHotelCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteHotelCommand, DeleteHotelResponse>
{
    public async Task<DeleteHotelResponse> Handle(DeleteHotelCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteHotelCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        var HotelRepo = _unitOfWork.GetRepository<Hotel>();

        await HotelRepo.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();
        
        return new DeleteHotelResponse(){};
    }
}