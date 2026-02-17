using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace GuestManagement.API.Extensions
{
    public static class ExceptionHandlingExtensions
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                    if (exception is ValidationException validationException)
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Title = "Validation Exception",
                            Errors = validationException.Errors.Select(e => e.ErrorMessage)
                        });
                    }
                });
            });
        }
    }
}
