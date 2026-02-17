using MediatR;

namespace GuestManagement.Application.Commands.Reservation
{
    public record CheckInReservationCommand(Guid Id) : IRequest<bool>;    
}
