using System.Linq.Expressions;
using NSubstitute;
using TravelAgency.Application.Handlers.Packages.CreatePackage;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.UnitTests.TestsUtils;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;
using Xunit;

namespace TravelAgency.Application.UnitTests.Packages;

public class CreatePackageCommandHandlerTest
{
    private readonly TestGenerator _generator = new TestGenerator();
    [Fact]
    public async void HandleCreatePackageCommand_WhenDataIsValid_ShouldCompleteOk()
    {
        // Arrange
        var command = new CreatePackageCommand(
            "Alturas de Bacunayagua",
            "Descripción emocionante",
            180,
            DateTime.Now,
            DateTime.Now.AddDays(3),
            [3, 4],
            [Guid.NewGuid(), Guid.NewGuid()]
        );

        var facilities = _generator.GenerateFacilities();
        var excursions = _generator.GenerateExcursions();

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var packageRepoMocked = Substitute.For<IGenericRepository<Package>>();
        var facilityRepoMocked = Substitute.For<IGenericRepository<Facility>>();
        var excursionRepoMocked = Substitute.For<IGenericRepository<Excursion>>();

        unitOfWorkMocked.GetRepository<Package>().Returns(packageRepoMocked);
        unitOfWorkMocked.GetRepository<Facility>().Returns(facilityRepoMocked);
        unitOfWorkMocked.GetRepository<Excursion>().Returns(excursionRepoMocked);

        facilityRepoMocked.FindAllAsync(filters: Arg.Any<IEnumerable<Expression<Func<Facility, bool>>>>())!.Returns(facilities);
        excursionRepoMocked.FindAllAsync(filters: Arg.Any<IEnumerable<Expression<Func<Excursion, bool>>>>())!.Returns(excursions);  

        var handler = new CreatePackageCommandHandler(unitOfWorkMocked);

        // Act
        var response = await handler.Handle(command, default);

        // Assert
        await packageRepoMocked.Received(1).InsertAsync(Arg.Any<Package>());
        await unitOfWorkMocked.Received(1).SaveAsync();
        Assert.Equal(response.ArrivalDate, command.ArrivalDate);
        Assert.Equal(response.DepartureDate, command.DepartureDate);
    }

    [Fact]
    public async void HandleCreatePackageCommand_WhenPriceIsNotValid_ShouldReturnAnError()
    {
        // Arrange
        var command = new CreatePackageCommand(
            "Alturas de Bacunayagua",
            "Descripción emocionante",
            -100,
            DateTime.Now,
            DateTime.Now.AddDays(3),
            [3, 4],
            [Guid.NewGuid(), Guid.NewGuid()]
        );

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var handler = new CreatePackageCommandHandler(unitOfWorkMocked);

        // Act & Assert
        await Assert.ThrowsAsync<TravelAgencyException>(async () => await handler.Handle(command, default));
    }

    [Fact]
    public async void HandleCreatePackageCommand_WhenDescriptionIsEmpty_ShouldReturnAnError()
    {
        // Arrange
        var command = new CreatePackageCommand(
            "Alturas de Bacunayagua",
            "",
            150,
            DateTime.Now,
            DateTime.Now.AddDays(3),
            [3, 4],
            [Guid.NewGuid(), Guid.NewGuid()]
        );

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var handler = new CreatePackageCommandHandler(unitOfWorkMocked);

        // Act & Assert
        await Assert.ThrowsAsync<TravelAgencyException>(async () => await handler.Handle(command, default));
    }
}