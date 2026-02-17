using FluentAssertions;
using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Application.Handlers;
using GuestManagement.Application.Queries;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Enums;
using GuestManagement.Domain.Interfaces;
using Moq;

namespace GuestManagement.Application.Tests.ReservationsTest
{
    public class DeleteReservationHandlerTests
    {
        private readonly Mock<IReservationRepository> _repositoryMock;
        private readonly DeleteReservationHandler _handler;
        public DeleteReservationHandlerTests()
        {
            _repositoryMock = new Mock<IReservationRepository>();
            _handler = new DeleteReservationHandler(_repositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_Delete_Reservation()
        {
            // Arrange
            Guid ReservationId = new Guid();
            var request = new DeleteReservationCommand(ReservationId);
            ReservationEntity reservation = new ReservationEntity
            {
                Id = ReservationId,
                GuestName = "Shree Krishna",
                GuestEmail = "radha@krisna.com",
                RoomNumber = "105",
                CheckInDate = DateTime.UtcNow,
                CheckOutDate = DateTime.UtcNow.AddDays(2),
                Status = ReservationStatus.CheckedIn,
                NumberOfGuests = 1,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _repositoryMock
                .Setup(x => x.GetReservationByIdAsync(ReservationId))
                .ReturnsAsync(reservation);

            _repositoryMock
               .Setup(x => x.DeleteReservationAsync(ReservationId))
               .ReturnsAsync(true);
            
            // Act
          
            var result = await _repositoryMock.Object.DeleteReservationAsync(ReservationId);

            _repositoryMock.Verify(x => x.DeleteReservationAsync(ReservationId), Times.Once);
        }
    }
}
