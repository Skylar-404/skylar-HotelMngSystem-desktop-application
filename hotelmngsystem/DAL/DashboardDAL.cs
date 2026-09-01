using hotelmngsystem.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    public class DashboardStats
    {
        public int TotalGuests { get; set; }
        public int AvailableRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public int TodaysArrivals { get; set; }
        public int TodaysDepartures { get; set; }
        public int ActiveReservations { get; set; }
        public decimal TodaysRevenue { get; set; }
    }

    public class DashboardDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        public DashboardStats GetStats()
        {
            DashboardStats stats = new DashboardStats();

            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                stats.TotalGuests = Scalar(conn, "SELECT COUNT(1) FROM Guests");

                stats.AvailableRooms = Scalar(conn, "SELECT COUNT(1) FROM Rooms WHERE Status = 'AVAILABLE'");

                stats.OccupiedRooms = Scalar(conn, "SELECT COUNT(1) FROM Rooms WHERE Status = 'OCCUPIED'");

                stats.ActiveReservations = Scalar(conn,
                    "SELECT COUNT(1) FROM Reservations WHERE Status IN ('PENDING','CONFIRMED','CHECKED_IN')");

                stats.TodaysArrivals = Scalar(conn,
                    "SELECT COUNT(1) FROM Reservations WHERE CheckInDate = CAST(GETDATE() AS DATE) AND Status <> 'CANCELLED'");

                stats.TodaysDepartures = Scalar(conn,
                    "SELECT COUNT(1) FROM Reservations WHERE CheckOutDate = CAST(GETDATE() AS DATE) AND Status <> 'CANCELLED'");

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ISNULL(SUM(Amount),0) FROM Payments WHERE CAST(PaymentDate AS DATE) = CAST(GETDATE() AS DATE) AND PaymentStatus = 'COMPLETED'", conn))
                {
                    stats.TodaysRevenue = (decimal)cmd.ExecuteScalar();
                }
            }

            return stats;
        }

        private int Scalar(SqlConnection conn, string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
