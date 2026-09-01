namespace hotelmngsystem.Models
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal BasePrice { get; set; }
        public string Status { get; set; } = "ACTIVE";
    }
}
