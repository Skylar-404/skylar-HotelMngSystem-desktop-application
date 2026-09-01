namespace hotelmngsystem.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public int RoomTypeID { get; set; }
        public string TypeName { get; set; }
        public decimal BasePrice { get; set; }
        public int? FloorNumber { get; set; }
        public string Status { get; set; } = "AVAILABLE";

        public static readonly string[] AllStatuses = {
            "AVAILABLE", "RESERVED", "OCCUPIED", "DIRTY", "MAINTENANCE", "OUT_OF_ORDER"
        };
    }
}
