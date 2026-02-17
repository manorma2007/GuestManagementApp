using FluentValidation;
using GuestManagement.Application.Commands.Reservation;

namespace GuestManagement.Application.Validators
{
    public class UpdateReservationCommandValidator : AbstractValidator<UpdateReservationCommand>
    {
        public UpdateReservationCommandValidator()
        {
            RuleFor(x => x.Reservation.GuestName)
                .NotNull().WithMessage("Guest name is required.")
                .NotEmpty().WithMessage("Guest name is required.")
                .MaximumLength(200);

            RuleFor(x => x.Reservation.GuestEmail)
                .NotNull().WithMessage("Guest email is required.")
                .NotEmpty().WithMessage("Guest email is required.")
                .MaximumLength(200)
                .EmailAddress();

            RuleFor(x => x.Reservation.RoomNumber)
                .MaximumLength(50);

            RuleFor(x => x.Reservation.CheckInDate)
               .LessThanOrEqualTo(x => x.Reservation.CheckOutDate).WithMessage("Check-in date & time must be before check-out date & time.");

            RuleFor(x => x.Reservation.CheckOutDate)
                .GreaterThanOrEqualTo(x => x.Reservation.CheckInDate).WithMessage("Check-out date & time must be after check-in date & time.");

            RuleFor(x => x.Reservation.Status.ToString())
                .NotEmpty()
                .MaximumLength(20);

            RuleFor(x => x.Reservation.NumberOfGuests)
                .NotNull().WithMessage("Number Of Guests is required.")
                .NotEmpty().WithMessage("Number Of Guests is required.")
                .InclusiveBetween(0, 100000)
                .WithMessage("Number Of Guests must be a number between 0 and 1,00,000");
        }
    }
}
