using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Queries
{
    public record GetReservationsByIdQuery(Guid Id) : IRequest<ReservationEntity>;
    
}
