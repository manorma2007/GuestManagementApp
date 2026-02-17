using GuestManagement.Domain.Entities;
using MediatR;

namespace GuestManagement.Application.Commands.Reservation
{
    public record UpdateReservationCommand(Guid ReservationId, ReservationEntity Reservation) : IRequest<ReservationEntity>;
}
