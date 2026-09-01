using System;

namespace hotelmngsystem.Models
{
    public class RoomOperation
    {
        public int OperationID { get; set; }
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public int? ReservationID { get; set; }
        public string OperationType { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public string Description { get; set; }
        public int PerformedBy { get; set; }
        public string PerformedByName { get; set; }
        public DateTime OperationDate { get; set; }

        public static readonly string[] AllTypes = {
            "CHECK_IN", "CHECK_OUT", "ROOM_CHANGE", "CLEANING", "MAINTENANCE", "STATUS_CHANGE"
        };
    }
}
