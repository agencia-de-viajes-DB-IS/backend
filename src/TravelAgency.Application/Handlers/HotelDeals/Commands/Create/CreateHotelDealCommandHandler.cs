using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Create;

public class CreateHotelDealCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateHotelDealCommand, CreateHotelDealResponse>
{
    public async Task<CreateHotelDealResponse> Handle(CreateHotelDealCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateHotelDealCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            var failedResponse = new CreateHotelDealResponse
            {
                Success = false,
                ValidationErrors = new List<string>(validationResult.Errors.Select(x => x.ErrorMessage))
            };
            return failedResponse;
        }

        var HotelDealRepo = _unitOfWork.GetRepository<HotelDeal>();

        var s = request;  
        var HotelDeal = new HotelDeal()
        {
            Name = request.Name,
            ArrivalDate = request.ArrivalDate,
            DepartureDate = request.DepartureDate,
            Description = request.Description ?? "No description",
            AgencyRelatedHotelDeals = request.AgencyRelatedHotelDeals,
            ExtendedExcursions = request.ExtendedExcursions,
            HotelId = request.HotelId,
            Price = request.Price 
        };

        await HotelDealRepo.InsertAsync(HotelDeal);
        await _unitOfWork.SaveAsync();

        var response = new CreateHotelDealResponse()
        {
            Id = HotelDeal.Id 
        };
        return response;
    }
}