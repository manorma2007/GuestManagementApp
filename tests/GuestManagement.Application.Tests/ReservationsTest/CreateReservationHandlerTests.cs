using FluentAssertions;
using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Application.Handlers;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Enums;
using GuestManagement.Domain.Interfaces;
using Moq;

namespace GuestManagement.Application.Tests.ReservationsTest
{
    public class CreateReservationHandlerTests
    {
        private readonly Mock<IReservationRepository> _repositoryMock;
        private readonly CreateReservationHandler _handler;

        public CreateReservationHandlerTests()
        {
            _repositoryMock = new Mock<IReservationRepository>();
            _handler = new CreateReservationHandler(_repositoryMock.Object);
        }

        [Fact]
       public async Task Handle_Should_Create_Reservation_And_Return_ReservationEntity()
        {
            // Arrange
            var request = new CreateReservationCommand(
               new ReservationEntity
               {
                   Id = Guid.NewGuid(),
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

            _repositoryMock.Setup(r => r.CreateReservationAsync(It.IsAny<ReservationEntity>()))
    .ReturnsAsync(request.Reservation);               
           
            // Act            

            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            
            result.Should().NotBeNull();
        }
    }
}
