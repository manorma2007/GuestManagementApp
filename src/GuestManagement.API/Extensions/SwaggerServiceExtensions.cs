using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace GuestManagement.API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Guest Management API",
                    Version = "v1",
                    Description = "<h3>Summary</h3>\r\n" +
                    "<p>This is 'Guest Management API' for Take-Home Assignment." +
                    "<br />Clean code architecture is used to develop this API endpoints." +
                    "<br />This API is useful to perform all the CRUD operations for reservations.</p>",
                });                
            });
            return services;
        }
    }
}
