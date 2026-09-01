using System;

namespace hotelmngsystem.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public string ReservationCode { get; set; }

        public int GuestID { get; set; }
        public string GuestName { get; set; }

        public int RoomID { get; set; }
        public string RoomNumber { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int Adults { get; set; } = 1;
        public int Children { get; set; } = 0;

        public decimal RoomRate { get; set; }

        public string Status { get; set; } = "PENDING";

        public string SpecialRequest { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static readonly string[] AllStatuses = {
            "PENDING", "CONFIRMED", "CHECKED_IN", "CHECKED_OUT", "CANCELLED", "NO_SHOW"
        };

        public int Nights => Math.Max(1, (CheckOutDate.Date - CheckInDate.Date).Days);
        public decimal TotalAmount => RoomRate * Nights;
    }
}
