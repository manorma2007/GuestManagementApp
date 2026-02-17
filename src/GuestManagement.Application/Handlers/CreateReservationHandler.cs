using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Handlers
{
    public class CreateReservationHandler(IReservationRepository reservationRepository)
        : IRequestHandler<CreateReservationCommand, ReservationEntity>
    {
        public async Task<ReservationEntity> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await reservationRepository.CreateReservationAsync(request.Reservation);           
            return reservation;
        }
    }
}
