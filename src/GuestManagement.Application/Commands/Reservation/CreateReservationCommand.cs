using GuestManagement.Domain.Entities;
using MediatR;

namespace GuestManagement.Application.Commands.Reservation
{
    public record CreateReservationCommand(ReservationEntity Reservation) : IRequest<ReservationEntity>;
   
}
 