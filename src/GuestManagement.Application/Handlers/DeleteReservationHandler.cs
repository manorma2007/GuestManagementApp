using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Handlers
{
    public class DeleteReservationHandler(IReservationRepository reservationRepository)
        : IRequestHandler<DeleteReservationCommand, bool>
    {
        public async Task<bool> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            return await reservationRepository.DeleteReservationAsync(request.ReservationId);
        }
    }
}
