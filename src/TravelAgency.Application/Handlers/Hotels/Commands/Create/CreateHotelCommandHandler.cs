using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Hotels.Commands.Create;

public class CreateHotelCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateHotelCommand, CreateHotelResponse>
{
    public async Task<CreateHotelResponse> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateHotelCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        var HotelRepo = _unitOfWork.GetRepository<Hotel>();

        var s = request;  
        var Hotel = new Hotel()
        {
            Address = request.Address,
            Name = request.Name,
            Category = request.Category,
            Deals = request.Deals
        };

        await HotelRepo.InsertAsync(Hotel);
        await _unitOfWork.SaveAsync();

        var response = new CreateHotelResponse()
        {
            Id = Hotel.Id,
            Name = Hotel.Name,
        };

        return response;
    }
}