using hotelmngsystem.Database;
using System;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    public class ReportDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        /// <summary>Guests with how many reservations they made and how much they paid, in a date range.</summary>
        public DataTable GetGuestActivityReport(DateTime from, DateTime to)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT g.GuestID, g.FirstName + ' ' + g.LastName AS Guest, g.Phone,
                         COUNT(DISTINCT res.ReservationID) AS TotalReservations,
                         ISNULL(SUM(p.Amount), 0) AS TotalPaid
                  FROM Guests g
                  LEFT JOIN Reservations res ON res.GuestID = g.GuestID
                       AND res.CheckInDate BETWEEN @from AND @to
                  LEFT JOIN Payments p ON p.ReservationID = res.ReservationID AND p.PaymentStatus = 'COMPLETED'
                  GROUP BY g.GuestID, g.FirstName, g.LastName, g.Phone
                  HAVING COUNT(DISTINCT res.ReservationID) > 0
                  ORDER BY TotalPaid DESC", conn))
            {
                cmd.Parameters.AddWithValue("@from", from.Date);
                cmd.Parameters.AddWithValue("@to", to.Date);
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
        }

        /// <summary>Reservations (occupancy) within a date range, with nights and total amount.</summary>
        public DataTable GetReservationReport(DateTime from, DateTime to)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT res.ReservationCode, g.FirstName + ' ' + g.LastName AS Guest, rm.RoomNumber,
                         res.CheckInDate, res.CheckOutDate,
                         DATEDIFF(DAY, res.CheckInDate, res.CheckOutDate) AS Nights,
                         res.RoomRate,
                         DATEDIFF(DAY, res.CheckInDate, res.CheckOutDate) * res.RoomRate AS TotalAmount,
                         res.Status
                  FROM Reservations res
                  JOIN Guests g ON g.GuestID = res.GuestID
                  JOIN Rooms rm ON rm.RoomID = res.RoomID
                  WHERE res.CheckInDate BETWEEN @from AND @to
                  ORDER BY res.CheckInDate DESC", conn))
            {
                cmd.Parameters.AddWithValue("@from", from.Date);
                cmd.Parameters.AddWithValue("@to", to.Date);
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
        }

        /// <summary>Completed payments (revenue) within a date range, broken down by method.</summary>
        public DataTable GetRevenueReport(DateTime from, DateTime to)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT p.PaymentMethod, p.PaymentType, COUNT(1) AS TransactionCount, SUM(p.Amount) AS TotalAmount
                  FROM Payments p
                  WHERE p.PaymentStatus = 'COMPLETED'
                        AND CAST(p.PaymentDate AS DATE) BETWEEN @from AND @to
                  GROUP BY p.PaymentMethod, p.PaymentType
                  ORDER BY TotalAmount DESC", conn))
            {
                cmd.Parameters.AddWithValue("@from", from.Date);
                cmd.Parameters.AddWithValue("@to", to.Date);
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
                return dt;
            }
        }

        public decimal GetTotalRevenue(DateTime from, DateTime to)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT ISNULL(SUM(Amount), 0) FROM Payments
                  WHERE PaymentStatus = 'COMPLETED' AND CAST(PaymentDate AS DATE) BETWEEN @from AND @to", conn))
            {
                cmd.Parameters.AddWithValue("@from", from.Date);
                cmd.Parameters.AddWithValue("@to", to.Date);
                conn.Open();
                return (decimal)cmd.ExecuteScalar();
            }
        }
    }
}
