using FluentValidation;
using GuestManagement.Application.Commands.Reservation;
using GuestManagement.Application.Common.Behaviors;
using GuestManagement.Application.Validators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GuestManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            
            services.AddMediatR(static cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            cfg.RegisterServicesFromAssembly(typeof(CreateReservationCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(UpdateReservationCommand).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CheckInReservationCommand).Assembly);
               
            });

            services.AddValidatorsFromAssembly(typeof(CreateReservationCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(UpdateReservationCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(CheckInReservationValidator).Assembly);                       
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                       
            return services;
           
        }
    }
}
