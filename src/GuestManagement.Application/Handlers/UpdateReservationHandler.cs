using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Handlers
{
   public class UpdateReservationHandler(IReservationRepository reservationRepository)
        : IRequestHandler<UpdateReservationCommand, ReservationEntity>
    {
        public async Task<ReservationEntity> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            return await reservationRepository.UpdateReservationAsync(request.ReservationId, request.Reservation);
        }
    }
}
