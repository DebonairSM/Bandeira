using Bandeira.Application.Abstractions.Clock;
using Bandeira.Application.Bookings.ReserveBooking;
using Bandeira.Domain.Abstractions;
using Bandeira.Domain.Persons;
using Bandeira.Domain.Bookings;
using Bandeira.Domain.Users;
using FluentAssertions;
using Moq;
using Bandeira.Domain.Cards;

namespace Bandeira.Application.UnitTests.Bookings;

public class ReserveBookingTests
{
    private static readonly User User = User.Create(
        new FirstName("test"),
        new LastName("test"),
        new Email("test@test.com"));

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenUserIsNull()
    {
        // Arrange
        var command = new ReserveBookingCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateOnly.Parse("01-01-2023"),
            DateOnly.Parse("10-01-2023"));

        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock
            .Setup(u => u.GetByIdAsync(It.IsAny<UserId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User?)null);

        var handler = new ReserveBookingCommandHandler(
            userRepositoryMock.Object,
            new Mock<IPersonRepository>().Object,
            new Mock<ICardRepository>().Object,
            new Mock<IUnitOfWork>().Object,
            new Mock<PricingService>().Object,
            new Mock<IDateTimeProvider>().Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Error.Should().Be(UserErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenPersonIsNull()
    {
        // Arrange
        var command = new ReserveBookingCommand(
            Guid.NewGuid(),
            Guid.NewGuid(),
            DateOnly.Parse("01-01-2023"),
            DateOnly.Parse("10-01-2023"));

        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock
            .Setup(u => u.GetByIdAsync(It.IsAny<UserId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(User);

        var personRepositoryMock = new Mock<IPersonRepository>();
        personRepositoryMock
            .Setup(u => u.GetByIdAsync(It.IsAny<PersonId>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Person?)null);


        var handler = new ReserveBookingCommandHandler(
            userRepositoryMock.Object,
            personRepositoryMock.Object,
            new Mock<ICardRepository>().Object,
            new Mock<IUnitOfWork>().Object,
            new Mock<PricingService>().Object,
            new Mock<IDateTimeProvider>().Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.Error.Should().Be(PersonErrors.NotFound);
    }
}
