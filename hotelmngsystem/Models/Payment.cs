using System;

namespace hotelmngsystem.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int ReservationID { get; set; }
        public string ReservationCode { get; set; }
        public string GuestName { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentType { get; set; }
        public string TransactionReference { get; set; }
        public string PaymentStatus { get; set; } = "COMPLETED";

        public int? ReceivedBy { get; set; }
        public string ReceivedByName { get; set; }
        public DateTime PaymentDate { get; set; }

        public static readonly string[] AllMethods = { "CASH", "CARD", "BANK_TRANSFER", "ONLINE", "OTHER" };
        public static readonly string[] AllTypes = { "DEPOSIT", "ROOM_PAYMENT", "EXTRA_CHARGE", "REFUND" };
        public static readonly string[] AllStatuses = { "PENDING", "COMPLETED", "REFUNDED", "VOID" };
    }
}
