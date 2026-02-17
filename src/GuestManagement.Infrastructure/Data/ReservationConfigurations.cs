using GuestManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GuestManagement.Infrastructure.Data
{
    public class ReservationConfigurations : IEntityTypeConfiguration<ReservationEntity>
    {
        public void Configure(EntityTypeBuilder<ReservationEntity> builder)
        {
            builder.Property(o => o.Status)
                .HasConversion<string>(); // Stores the enum as a string in DB
        }
    }
}
