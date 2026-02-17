using GuestManagement.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace GuestManagement.API
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : Microsoft.AspNetCore.Diagnostics.IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext context, Exception exception, CancellationToken cancellationToken)
        {
            logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

            var problemDetails = new ProblemDetails
            {
                Instance = context.Request.Path,
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred",
                Detail = exception.Message // For security, consider a generic message in production
            };

            // Map exceptions to specific HTTP status codes
            problemDetails.Status = exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status400BadRequest,
                NullReferenceException => StatusCodes.Status400BadRequest,               
                _ => StatusCodes.Status500InternalServerError
            };
            problemDetails.Title = exception.GetType().Name;

            context.Response.StatusCode = problemDetails.Status.Value;
            await context.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true; // Return true to indicate the exception has been handled
        }
    }
}
