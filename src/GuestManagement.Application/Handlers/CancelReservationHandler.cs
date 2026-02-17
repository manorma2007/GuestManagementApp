using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Handlers
{
    public class CancelReservationHandler(IReservationRepository reservationRepository)
        : IRequestHandler<CancelReservationCommand, bool>
    {
        public async Task<bool> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            return await reservationRepository.CancelReservationAsync(request.Id);
        }
    }
}
