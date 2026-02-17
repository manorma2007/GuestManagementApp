using GuestManagement.Application.Queries;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Handlers
{
    public class GetAllReservationsHandler(IReservationRepository reservationRepository)
        : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationEntity>>
    {
        public async Task<IEnumerable<ReservationEntity>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            return await reservationRepository.GetReservations();
        }
    }
}

