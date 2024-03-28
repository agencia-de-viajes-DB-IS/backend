using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Delete;

public class DeleteHotelDealCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeleteHotelDealCommand, DeleteHotelDealResponse>
{
    public async Task<DeleteHotelDealResponse> Handle(DeleteHotelDealCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteHotelDealCommandValidator();
        await validator.ValidateAsync(request, cancellationToken);

        var HotelDealRepo = _unitOfWork.GetRepository<HotelDeal>();

        await HotelDealRepo.DeleteAsync(request.Id);
        await _unitOfWork.SaveAsync();
        
        return new DeleteHotelDealResponse(){};
    }
}