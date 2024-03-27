using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Hotels.Commands.Update;

public class UpdateHotelCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateHotelCommand, UpdateHotelResponse>
{
    public async Task<UpdateHotelResponse> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateHotelCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        var hotelRepo = _unitOfWork.GetRepository<Hotel>();
        
        var hotel = (await hotelRepo.FindAllAsync(filters: [
            hotel => hotel.Id == request.Id
        ])).FirstOrDefault() ?? throw new TravelAgencyException("hotel was not found", $"hotel with Id {request.Id} was not found", 404);

        hotel.Address = request.Address ?? hotel.Address;
        hotel.Name = request.Name ?? hotel.Name;
        hotel.Category = request.Category ?? hotel.Category;
        hotel.Deals = request.Deals ?? hotel.Deals; 

        await hotelRepo.UpdateAsync(hotel);
        await _unitOfWork.SaveAsync();

        var response = new UpdateHotelResponse()
        {
            Id = hotel.Id,
        };

        return response;
    }
}