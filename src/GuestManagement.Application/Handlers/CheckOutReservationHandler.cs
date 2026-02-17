using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Handlers
{
    public class CheckOutReservationHandler  : IRequestHandler<CheckOutReservationCommand, bool>
    {
        private readonly IReservationRepository _repository;

        public CheckOutReservationHandler(IReservationRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(CheckOutReservationCommand request, CancellationToken cancellationToken)
        {     
            return await _repository.CheckOutReservationAsync(request.Id);
        }
    }
}
