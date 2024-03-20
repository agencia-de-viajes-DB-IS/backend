using System.Linq.Expressions;
using NSubstitute;
using TravelAgency.Application.Handlers.Authentication.Login;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Application.UnitTests.TestsUtils;
using TravelAgency.Domain.Common.Exceptions;
using TravelAgency.Domain.Entities;
using Xunit;

namespace TravelAgency.Application.UnitTests.Authentication.Login;

public class LoginCommandHandlerTest
{
    [Fact]
    public async void HandleLoginQuery_WheEmailIsRegisteredAndPasswordIsCorrect_ShouldCompleteOk()
    {
        // Arrange
        var user = TestGenerator.GenerateUser();
        var command = new LoginQuery(user.Email, user.Password);
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
        userRepoMocked.FindAsync(filters: Arg.Any<IEnumerable<Expression<Func<User, bool>>>>())!.Returns(Task.FromResult(user));
        jwtGeneratorMock.GenerateToken(Arg.Any<User>()).Returns(TOKEN);

        var handler = new LoginQueryHandler(jwtGeneratorMock, unitOfWorkMocked);

        // Act
        var response = await handler.Handle(command, default);

        // Assert
        Assert.Equal(user.Email, response.Email);
        Assert.Equal(TOKEN, response.Token);
    }

    [Fact]
    public async void HandleLoginQuery_WheEmailIsRegisteredAndPasswordIsNotCorrect_ShouldThrowException()
    {
        // Arrange
        var user = TestGenerator.GenerateUser();
        var command = new LoginQuery(user.Email, "wrong_password");

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var userRepoMocked = Substitute.For<IGenericRepository<User>>();
        var jwtGeneratorMock = Substitute.For<IJwtTokenGenerator>();

        var userFilter = new Expression<Func<User, bool>>[]
        {
            u => u.Email == command.Email
        };

        unitOfWorkMocked.GetRepository<User>().Returns(userRepoMocked);
        userRepoMocked.FindAsync(filters: Arg.Any<IEnumerable<Expression<Func<User, bool>>>>())!.Returns(Task.FromResult(user));

        var handler = new LoginQueryHandler(jwtGeneratorMock, unitOfWorkMocked);

        // Act and Assert
        await Assert.ThrowsAsync<TravelAgencyException>(async () => await handler.Handle(command, default));
    }

    [Fact]
    public async void HandleLoginQuery_WheEmailIsNotRegistered_ShouldThrowException()
    {
        // Arrange
        var user = TestGenerator.GenerateUser();
        var command = new LoginQuery(user.Email, user.Password);

        // Mocking services
        var unitOfWorkMocked = Substitute.For<IUnitOfWork>();
        var userRepoMocked = Substitute.For<IGenericRepository<User>>();
        var jwtGeneratorMock = Substitute.For<IJwtTokenGenerator>();

        var userFilter = new Expression<Func<User, bool>>[]
        {
            u => u.Email == command.Email
        };

        unitOfWorkMocked.GetRepository<User>().Returns(userRepoMocked);
        userRepoMocked.FindAsync(filters: Arg.Any<IEnumerable<Expression<Func<User, bool>>>>())!.Returns(Task.FromResult<User>(null!));

        var handler = new LoginQueryHandler(jwtGeneratorMock, unitOfWorkMocked);

        // Act and Assert
        await Assert.ThrowsAsync<TravelAgencyException>(async () => await handler.Handle(command, default));
    }
}