using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.HotelDeals.Commands.Create;

public class CreateHotelDealCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<CreateHotelDealCommand, HotelDealResponse>
{
    public async Task<HotelDealResponse> Handle(CreateHotelDealCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateHotelDealCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count > 0)
        {
            var failedResponse = new HotelDealResponse
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

        var response = new HotelDealResponse()
        {
            Id = HotelDeal.Id 
        };
        return response;
    }
}