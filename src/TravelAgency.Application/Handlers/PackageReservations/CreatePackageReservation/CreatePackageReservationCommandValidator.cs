using FluentValidation;
using TravelAgency.Application.Common;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.PackageReservations.CreatePackageReservation;

public class CreatePackageReservationCommandValidator : TravelAgencyAbstractValidator<CreatePackageReservationCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreatePackageReservationCommandValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        // Validation process
        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
        RuleFor(x => x)
            .MustAsync(async (x, _) => await ValidateAvailableCapacity(x));
        RuleFor(x => x)
            .MustAsync(async (x, _) => await ValidateReservationDate(x));
        RuleForEach(x => x.TouristsGuid)
                .MustAsync(async (id, token) => await unitOfWork.GetRepository<Tourist>().ExistsAsync(e => e.Id == id && e.Flag))
                .WithMessage("TOurist GUID is not found");
    }

    private async Task<bool> ValidateAvailableCapacity(CreatePackageReservationCommand request)
    {
        var packageRepo = _unitOfWork.GetRepository<Package>();
        var packageReservationRepo = _unitOfWork.GetRepository<PackageReservation>();

        var availableCapacity = await packageRepo.AvailableCapacity(packageReservationRepo, request.PackageId);
        if (availableCapacity < request.TouristsGuid.Count())
            throw new TravelAgencyException("Insufficient capacity", $"Available capacity {availableCapacity}", status: 400);

        return true;
    }
    private async Task<bool> ValidateReservationDate(CreatePackageReservationCommand request)
    {
        var packageRepo = _unitOfWork.GetRepository<Package>();

        var package = await packageRepo.FindAsync(filters: [package => package.Code == request.PackageId]) ?? throw new TravelAgencyException("Package not found", status: 404);

        if (request.ReservationDate >= package.ArrivalDate)
            throw new TravelAgencyException("Reservation-date must be smaller than package's arrival-date", status: 400);

        return true;
    }
}