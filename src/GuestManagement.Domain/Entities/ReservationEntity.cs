using GuestManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestManagement.Domain.Entities
{
    public class ReservationEntity
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string RoomNumber { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        public ReservationStatus Status { get; set; }
        public int? NumberOfGuests { get; set; } = 2;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
