using MediatR;

namespace GuestManagement.Application.Commands.Reservation
{
    public record CancelReservationCommand(Guid Id) : IRequest<bool>;
}