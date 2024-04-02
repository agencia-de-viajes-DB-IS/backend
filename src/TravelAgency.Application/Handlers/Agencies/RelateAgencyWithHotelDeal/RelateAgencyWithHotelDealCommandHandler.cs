using MediatR;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.RelateAgencyWithHotelDeal;

public class RelateAgencyWithHotelDealCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<RelateAgencyWithHotelDealCommand, RelateAgencyWithHotelDealResponse>
{
    public async Task<RelateAgencyWithHotelDealResponse> Handle(RelateAgencyWithHotelDealCommand request, CancellationToken cancellationToken)
    {
        var validator = new RelateAgencyWithHotelDealCommandValidator(_unitOfWork);
        await validator.ValidateAsync(request);

        var agencyRelatedHotelDealRepo = _unitOfWork.GetRepository<AgencyRelatedHotelDeal>();
        
        var agencyRelatedHotelDeal = new AgencyRelatedHotelDeal()
        {
            AgencyId = request.AgencyId,
            HotelDealId = request.HotelDealId
        };

        await agencyRelatedHotelDealRepo.InsertAsync(agencyRelatedHotelDeal);
        await _unitOfWork.SaveAsync();

        var response = new RelateAgencyWithHotelDealResponse(
            agencyRelatedHotelDeal.AgencyId,
            agencyRelatedHotelDeal.HotelDealId
        );

        return response;
    }
}