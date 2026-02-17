using FluentAssertions;
using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Application.Handlers;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Enums;
using GuestManagement.Domain.Interfaces;
using Moq;

namespace GuestManagement.Application.Tests.ReservationsTest
{
    public class UpdateReservationHandlerTests
    {
        private readonly Mock<IReservationRepository> _repositoryMock;
        private readonly UpdateReservationHandler _handler;

        public UpdateReservationHandlerTests()
        {
            _repositoryMock = new Mock<IReservationRepository>();
            _handler = new UpdateReservationHandler(_repositoryMock.Object);
        }
        [Fact]
        public async Task Handle_Should_Update_Reservation()
        {
            // Arrange
            var reservationId = Guid.NewGuid();
            var request = new UpdateReservationCommand(reservationId,
               new ReservationEntity
               {
                   Id = reservationId,
                   GuestName = "Shree Ram",
                   GuestEmail = "shree@ram.com",
                   RoomNumber = "101",
                   CheckInDate = DateTime.UtcNow,
                   CheckOutDate = DateTime.UtcNow.AddDays(2),
                   Status = ReservationStatus.CheckedIn,
                   NumberOfGuests = 2,
                   CreatedAt = DateTime.UtcNow,
                   UpdatedAt = DateTime.UtcNow
               });

            _repositoryMock
                .Setup(x => x.GetReservationByIdAsync(reservationId))
                .ReturnsAsync(request.Reservation);

            request.Reservation.GuestName = "Jay Shree Ram";

            _repositoryMock
                .Setup(x => x.UpdateReservationAsync(reservationId, request.Reservation))
                .ReturnsAsync(request.Reservation);

            // Act  

            var result = await _repositoryMock.Object.UpdateReservationAsync(reservationId, request.Reservation);
            // Assert
            result.Should().NotBeNull();
            result.GuestName.Should().Be("Jay Shree Ram");
            _repositoryMock.Verify(x => x.UpdateReservationAsync(reservationId, request.Reservation), Times.Once);
        }
    }
}
