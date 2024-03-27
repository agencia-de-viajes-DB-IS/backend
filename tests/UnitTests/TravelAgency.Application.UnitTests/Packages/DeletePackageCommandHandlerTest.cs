using System.Linq.Expressions;
using NSubstitute;
using TravelAgency.Application.Handlers.Packages.DeletePackage;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.UnitTests.TestsUtils;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;
using Xunit;

namespace TravelAgency.Application.UnitTests.Packages;

public class DeletePackageCommandHandlerTest
{
    private readonly TestGenerator _generator = new TestGenerator();
    [Fact]
    public async void HandleDeletePackageCommand_WhenPackageExists_ShouldCompleteOk()
    {
        // Arrange
        var packages = _generator.GeneratePackages();
        var package = packages.First();
        var command = new DeletePackageCommand(package.Code);

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var packageRepoMocked = Substitute.For<IGenericRepository<Package>>();

        unitOfWorkMocked.GetRepository<Package>().Returns(packageRepoMocked);

        packageRepoMocked.FindAllAsync(filters: Arg.Any<IEnumerable<Expression<Func<Package, bool>>>>())!.Returns(packages);

        var handler = new DeletePackageCommandHandler(unitOfWorkMocked);

        // Act
        var response = await handler.Handle(command, default);

        // Assert
        await packageRepoMocked.Received(1).DeleteAsync(Arg.Any<Guid>());
        await unitOfWorkMocked.Received(1).SaveAsync();
        Assert.Equal(package.Code, response.Code);
    }

    [Fact]
    public async void HandleDeletePackageCommand_WhenPackageDoesNotExist_ShouldReturnAnError()
    {
        // Arrange
        var command = new DeletePackageCommand(Guid.NewGuid());
        var packages = new List<Package>();

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var packageRepoMocked = Substitute.For<IGenericRepository<Package>>();

        unitOfWorkMocked.GetRepository<Package>().Returns(packageRepoMocked);

        packageRepoMocked.FindAllAsync(filters: Arg.Any<IEnumerable<Expression<Func<Package, bool>>>>())!.Returns(packages);

        var handler = new DeletePackageCommandHandler(unitOfWorkMocked);

        // Act & Assert
        await Assert.ThrowsAsync<TravelAgencyException>(async () => await handler.Handle(command, default));
    }
}