using FluentAssertions;
using GuestManagement.Application.Handlers;
using GuestManagement.Application.Queries;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Enums;
using GuestManagement.Domain.Interfaces;
using Moq;
namespace GuestManagement.Application.Tests.ReservationsTest
{
    public class GetReservationByIdHandlerTests
    {
        private readonly Mock<IReservationRepository> _repositoryMock;
        private readonly GetReservationByIdHandler _handler;
        public GetReservationByIdHandlerTests()
        {
            _repositoryMock = new Mock<IReservationRepository>();
            _handler = new GetReservationByIdHandler(_repositoryMock.Object);
        }
        [Fact]
        public async Task Handle_Should_Return_Reservation_When_Found()
        {
            // Arrange
            Guid ReservationId = new Guid();
            var request = new GetReservationsByIdQuery(ReservationId);
            ReservationEntity reservation = new ReservationEntity
            {
                Id = Guid.NewGuid(),
                GuestName = "Radha Rani",
                GuestEmail = "Radha@rani.com",
                RoomNumber = "101",
                CheckInDate = DateTime.UtcNow,
                CheckOutDate = DateTime.UtcNow.AddDays(2),
                Status = ReservationStatus.CheckedIn,
                NumberOfGuests = 2,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _repositoryMock
                .Setup(x => x.GetReservationByIdAsync(ReservationId))
                .ReturnsAsync(reservation);

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.GuestName.Should().Be("Radha Rani");
        }
    }
}
