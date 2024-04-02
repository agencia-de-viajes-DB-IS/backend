using System.Linq.Expressions;
using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Agencies.RelateAgencyWithHotelDeal;

public class RelateAgencyWithHotelDealCommandValidator : TravelAgencyAbstractValidator<RelateAgencyWithHotelDealCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public RelateAgencyWithHotelDealCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        // Validation process
        RuleFor(agency => agency.AgencyId).MustAsync(async (agencyId, _) => await ValidateAgencyId(agencyId));
        RuleFor(x => x.HotelDealId).MustAsync(async (x, _) => await ValidateHotelDealId(x));
    }

    private async Task<bool> ValidateAgencyId(Guid agencyId)
    {
        var agencyRepo = _unitOfWork.GetRepository<Agency>();

        return (await agencyRepo.FindAsync(filters: [agency => agency.Id == agencyId])) is null ? throw new TravelAgencyException("Agency not found", $"Agency with id {agencyId} was not found", status: 404) : true;
    }

    private async Task<bool> ValidateHotelDealId(Guid hotelDealId)
    {
        var hotelDealRepo = _unitOfWork.GetRepository<HotelDeal>();

        return (await hotelDealRepo.FindAsync(filters: [hotelDeal => hotelDeal.Id == hotelDealId])) is null ? throw new TravelAgencyException("Hotel Deal not found", $"Hotel Deal with id {hotelDealId} was not found", status: 404) : true;
    }
}