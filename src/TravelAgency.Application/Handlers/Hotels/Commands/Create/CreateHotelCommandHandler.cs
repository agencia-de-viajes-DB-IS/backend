using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Hotels.Commands.Create;

public class CreateHotelCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateHotelCommand, HotelResponse>
{
    public async Task<HotelResponse> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateHotelCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            var failedResponse = new HotelResponse
            {
                Success = false,
                ValidationErrors = new List<string>(validationResult.Errors.Select(x => x.ErrorMessage))
            };
            return failedResponse;
        }

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

        var response = new HotelResponse()
        {
            Id = Hotel.Id,
            Name = Hotel.Name,
        };

        return response;
    }
}