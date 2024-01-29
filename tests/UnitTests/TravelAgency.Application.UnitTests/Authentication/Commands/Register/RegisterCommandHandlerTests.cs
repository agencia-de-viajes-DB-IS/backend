using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using TravelAgency.Application.Authentication.Commands.Register;
using TravelAgency.Application.Interfaces.Authentication;
using TravelAgency.Application.Interfaces.Persistence;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Application.UnitTests.Authentication.Commands.Register;

public class RegisterCommandHandlerTests
{
    [Fact]
    public async void HandleRegisteCommand_WheEmailIsAlreadyRegistered_ShouldReturnAnError()
    {
        // Arrange
        var command = new RegisterCommand("Pancho", "Villa", "pan@gmail.com", "panchpass");

        // Mocking services
        var userRepoMock = Substitute.For<IUserRepository>();
        userRepoMock.GetUserByEmail(command.Email).Returns(new User());
        var jwtGeneratorMock = Substitute.For<IJwtTokenGenerator>();

        var handler = new RegisterCommandHandler(jwtGeneratorMock, userRepoMock);

        // Act
        var response = await handler.Handle(command, default);

        // Assert
        response.ErrorMessage.Should().Be("Email has been already registered");
        response.Success.Should().Be(false);
    }
}