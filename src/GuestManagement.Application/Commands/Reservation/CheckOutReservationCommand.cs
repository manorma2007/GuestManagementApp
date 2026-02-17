using MediatR;

namespace GuestManagement.Application.Commands.Reservation
{
    public record CheckOutReservationCommand(Guid Id) : IRequest<bool>;    
}
