using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Domain.Interfaces;
using MediatR;

namespace GuestManagement.Application.Handlers
{
    public class CheckInReservationHandler : IRequestHandler<CheckInReservationCommand, bool>
      {
        private readonly IReservationRepository _repository;

        public CheckInReservationHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CheckInReservationCommand request, CancellationToken cancellationToken)
        {    
            return await _repository.CheckInReservationAsync(request.Id);
        }
    }
}
