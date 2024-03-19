using System.Linq.Expressions;
using MediatR;
using TravelAgency.Application.Handlers.Packages.GetPackages;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.Handlers.Packages.DeletePackage;

public class DeletePackageCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<DeletePackageCommand, DeletePackageResponse>
{
    public async Task<DeletePackageResponse> Handle(DeletePackageCommand request, CancellationToken cancellationToken)
    {
        var packageRepo = _unitOfWork.GetRepository<Package>();
        
        var packageFilter = new Expression<Func<Package, bool>>[]
        {
            package => package.Code == request.Code
        };

        var package = (await packageRepo.FindAllAsync(filters: packageFilter)).FirstOrDefault() ??
            throw new TravelAgencyException("Package was not found", $"Package with code {request.Code} was not found", 404);

        await packageRepo.DeleteAsync(request.Code);
        await _unitOfWork.SaveAsync();

        return new DeletePackageResponse(request.Code);
    }
}