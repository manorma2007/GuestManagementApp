using GuestManagement.Domain.Interfaces;
using GuestManagement.Domain.Options;
using GuestManagement.Infrastructure.Data;
using GuestManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GuestManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>((options) =>
            //{
            //    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GuestManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            //});

            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddScoped<IReservationRepository, ReservationRepository>();
            
            return services;
        }
    }    
}
