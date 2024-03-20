using System.Linq.Expressions;
using NSubstitute;
using TravelAgency.Application.Handlers.Authentication.Register;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.UnitTests.TestsUtils;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;
using Xunit;

namespace TravelAgency.Application.UnitTests.Authentication.Register;

public class RegisterCommandHandlerTests
{
    [Fact]
    public async void HandleRegisterCommand_WheEmailIsNotRegistered_ShouldCompleteOk()
    {
        // Arrange
        var command = new RegisterCommand("John", "Doe", "doe@gmail.com", "doePass");
        const string TOKEN = "jwt_token";

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var userRepoMocked = Substitute.For<IGenericRepository<User>>();
        var jwtGeneratorMock = Substitute.For<IJwtTokenGenerator>();

        var userFilter = new Expression<Func<User, bool>>[]
        {
            u => u.Email == command.Email
        };

        unitOfWorkMocked.GetRepository<User>().Returns(userRepoMocked);
        userRepoMocked.FindAsync(filters: userFilter)!.Returns(Task.FromResult<User>(null!));
        jwtGeneratorMock.GenerateToken(Arg.Any<User>()).Returns(TOKEN);

        var handler = new RegisterCommandHandler(jwtGeneratorMock, unitOfWorkMocked);

        // Act
        var response = await handler.Handle(command, default);

        // Assert
        await userRepoMocked.Received(1).InsertAsync(Arg.Any<User>());
        await unitOfWorkMocked.Received(1).SaveAsync();
        Assert.Equal(command.Email, response.Email);
        Assert.Equal(TOKEN, response.Token);
    }

    [Fact]
    public async void HandleRegisterCommand_WheEmailIsAlreadyRegistered_ShouldReturnAnError()
    {
        // Arrange
        var command = new RegisterCommand("John", "Doe", "doe@gmail.com", "doePass");

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var userRepoMocked = Substitute.For<IGenericRepository<User>>();
        var jwtGeneratorMock = Substitute.For<IJwtTokenGenerator>();

        unitOfWorkMocked.GetRepository<User>().Returns(userRepoMocked);
        userRepoMocked.FindAsync(filters: Arg.Any<IEnumerable<Expression<Func<User, bool>>>>())!.Returns(Task.FromResult(TestGenerator.GenerateUser()));

        var handler = new RegisterCommandHandler(jwtGeneratorMock, unitOfWorkMocked);

        // Act
        await Assert.ThrowsAsync<TravelAgencyException>(async () => await handler.Handle(command, default));
    }
}