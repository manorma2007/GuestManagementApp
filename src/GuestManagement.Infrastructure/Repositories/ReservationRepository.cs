using GuestManagement.Application.Common.Exceptions;
using GuestManagement.Domain.Entities;
using GuestManagement.Domain.Enums;
using GuestManagement.Domain.Interfaces;
using GuestManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GuestManagement.Infrastructure.Repositories
{
    public class ReservationRepository(AppDbContext dbContext) : IReservationRepository
    {
        public async Task<ReservationEntity> CreateReservationAsync(ReservationEntity entity)
        {
            entity.Id = new Guid(); 
            dbContext.Reservations.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }
        public async Task<IEnumerable<ReservationEntity>> GetReservations()
        {
            return await dbContext.Reservations.ToListAsync();
        }
        public async Task<ReservationEntity> GetReservationByIdAsync(Guid Id)
        {
            return await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == Id);
        }
        public async Task<ReservationEntity> UpdateReservationAsync(Guid Id, ReservationEntity entity)
        {
            var reservation = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == Id);

            if (reservation is not null)
            {
                reservation.GuestName = entity.GuestName;
                reservation.GuestEmail = entity.GuestEmail;
                reservation.RoomNumber = entity.RoomNumber;
                reservation.CheckInDate = entity.CheckInDate;
                reservation.CheckOutDate = entity.CheckOutDate;
                reservation.Status = entity.Status;
                reservation.NumberOfGuests = entity.NumberOfGuests;                
                reservation.UpdatedAt = System.DateTime.UtcNow;

                await dbContext.SaveChangesAsync();

                return reservation;
            }
            else
            {
                throw new NotFoundException($"Reservations with ID {Id} not found.");
            }
            return entity;
        }

        public async Task<bool> CheckInReservationAsync(Guid Id)
        {
            var reservation = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == Id);
            if (reservation != null)
            {                
                reservation.Status = ReservationStatus.CheckedIn; 
                reservation.CheckInDate = System.DateTime.UtcNow;
                reservation.UpdatedAt = System.DateTime.UtcNow;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"Reservations with ID {Id} not found.");
            }
            return true;
        }

        public async Task<bool> CheckOutReservationAsync(Guid Id)
        {
            var reservation = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == Id);
            if (reservation != null)
            {
                reservation.Status = ReservationStatus.CheckedOut;
                reservation.CheckOutDate = System.DateTime.UtcNow;
                reservation.UpdatedAt = System.DateTime.UtcNow;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"Reservations with ID {Id} not found.");
            }
            return true;
        }

        public async Task<bool> CancelReservationAsync(Guid Id)
        {
            var reservation = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == Id);

            if (reservation is not null)
            {
                dbContext.Reservations.Remove(reservation);

                return await dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                throw new NotFoundException($"Reservations with ID {Id} not found.");
            }
        }


        public async Task<bool> DeleteReservationAsync(Guid Id)
        {
            var reservation = await dbContext.Reservations.FirstOrDefaultAsync(x => x.Id == Id);

            if (reservation is not null)
            {
                dbContext.Reservations.Remove(reservation);

                return await dbContext.SaveChangesAsync() > 0;
            }
            else
            {
                throw new NotFoundException($"Reservations with ID {Id} not found.");
            }
        }
    }
}
