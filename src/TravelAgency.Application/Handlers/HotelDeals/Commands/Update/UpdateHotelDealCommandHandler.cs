using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Update;

public class UpdateHotelDealCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateHotelDealCommand, UpdateHotelDealResponse>
{
    public async Task<UpdateHotelDealResponse> Handle(UpdateHotelDealCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateHotelDealCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        var hotelDealRepo = _unitOfWork.GetRepository<HotelDeal>();
        var hotelRepo =  _unitOfWork.GetRepository<Hotel>();
        
        var hotelDeal = (await hotelDealRepo.FindAllAsync(filters: [
            hotelDeal => hotelDeal.Id == request.Id
        ])).FirstOrDefault() ?? throw new TravelAgencyException("hotelDeal was not found", $"hotelDeal with Id {request.Id} was not found", 404);

        hotelDeal.ArrivalDate = request.ArrivalDate ?? hotelDeal.ArrivalDate;
        hotelDeal.DepartureDate = request.DepartureDate ?? hotelDeal.DepartureDate;
        hotelDeal.Description = request.Description ?? hotelDeal.Description;
        hotelDeal.HotelId = request.HotelId ?? hotelDeal.HotelId;
        hotelDeal.Price = request.Price ?? hotelDeal.Price;
        hotelDeal.Capacity = request.Capacity;
        
        await hotelDealRepo.UpdateAsync(hotelDeal);
        await _unitOfWork.SaveAsync();

        var response = new UpdateHotelDealResponse()
        {
            Id = hotelDeal.Id,
        };

        return response;
    }
}