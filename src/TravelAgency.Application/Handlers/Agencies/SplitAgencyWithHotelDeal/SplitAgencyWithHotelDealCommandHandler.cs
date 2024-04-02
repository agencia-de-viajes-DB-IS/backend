using MediatR;
using TravelAgency.Application.Handlers.Agencies.RelateAgencyWithHotelDeal;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.SplitAgencyWithHotelDeal;

public class SplitAgencyWithHotelDealCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<SplitAgencyWithHotelDealCommand, RelateAgencyWithHotelDealResponse>
{
    public async Task<RelateAgencyWithHotelDealResponse> Handle(SplitAgencyWithHotelDealCommand request, CancellationToken cancellationToken)
    {
        var agencyRelatedHotelDealRepo = _unitOfWork.GetRepository<AgencyRelatedHotelDeal>();
        
        var agencyRelatedHotelDeal = (await agencyRelatedHotelDealRepo.FindAsync(
            filters:
            [
                relation => relation.AgencyId == request.AgencyId,
                relation => relation.HotelDealId == request.HotelDealId
            ])) ?? throw new TravelAgencyException(message: "AgencyRelatedHotelDeal not found", status: 404);

        await agencyRelatedHotelDealRepo.DeleteAsync(agencyRelatedHotelDeal.Id);
        await _unitOfWork.SaveAsync();

        var response = new RelateAgencyWithHotelDealResponse(
            request.AgencyId,
            request.HotelDealId
        );

        return response;
    }
}