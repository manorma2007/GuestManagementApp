using FluentValidation;
using GuestManagement.Application.Commands.Reservation;

namespace GuestManagement.Application.Validators
{
    public class CheckInReservationValidator : AbstractValidator<CheckInReservationCommand>
    {
        public CheckInReservationValidator()
        {
         RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Id must be a valid non-empty GUID.");
        }
    }
}
