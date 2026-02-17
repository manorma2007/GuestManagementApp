using MediatR;

namespace GuestManagement.Application.Commands.Reservation
{
    public record DeleteReservationCommand(Guid ReservationId) : IRequest<bool>;

}
