using GuestManagement.Domain.Entities;

namespace GuestManagement.Domain.Interfaces
{
    public interface IReservationRepository
    {
        Task<ReservationEntity> CreateReservationAsync(ReservationEntity entity);
        Task<IEnumerable<ReservationEntity>> GetReservations();
        Task<ReservationEntity> GetReservationByIdAsync(Guid Id);
        Task<ReservationEntity> UpdateReservationAsync(Guid Id, ReservationEntity entity);
        Task<bool> CheckInReservationAsync(Guid Id);
        Task<bool> CheckOutReservationAsync(Guid Id);
        Task<bool> CancelReservationAsync(Guid Id);
        Task<bool> DeleteReservationAsync(Guid Id);
    }
}
