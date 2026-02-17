using GuestManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using System.Xml.Linq;

namespace GuestManagement.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<ReservationEntity> Reservations { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{            
        //    modelBuilder.Entity<ReservationEntity>()
        //        .Property(p => p.Id)
        //        .ValueGeneratedOnAdd()
        //        .HasDefaultValueSql("NEWID()"); 
        //}
    }
}
