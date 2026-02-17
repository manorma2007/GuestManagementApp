using GuestManagement.Application;
using GuestManagement.Domain;
using GuestManagement.Infrastructure;

namespace GuestManagement.API
{    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddDomainDI(configuration);

            return services;
        }
    }
}
