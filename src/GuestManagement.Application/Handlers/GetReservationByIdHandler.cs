using GuestManagement.Application.Queries;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Handlers

{
    public class GetReservationByIdHandler(IReservationRepository reservationRepository)
        : IRequestHandler<GetReservationsByIdQuery, ReservationEntity>
    {
        public async Task<ReservationEntity> Handle(GetReservationsByIdQuery request, CancellationToken cancellationToken)
        {
            return await reservationRepository.GetReservationByIdAsync(request.Id);
        }
    }
}

