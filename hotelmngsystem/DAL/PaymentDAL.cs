using hotelmngsystem.Database;
using hotelmngsystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    public class PaymentDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        public DataTable GetPayments(string search = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT p.PaymentID, res.ReservationID, res.ReservationCode, g.FirstName + ' ' + g.LastName AS Guest,
                                       p.Amount, p.PaymentMethod, p.PaymentType, p.PaymentStatus,
                                       p.TransactionReference, u.FullName AS ReceivedBy, p.PaymentDate
                                FROM Payments p
                                JOIN Reservations res ON res.ReservationID = p.ReservationID
                                JOIN Guests g ON g.GuestID = res.GuestID
                                LEFT JOIN Users u ON u.UserID = p.ReceivedBy
                                WHERE (@search IS NULL OR @search = ''
                                       OR res.ReservationCode LIKE '%' + @search + '%'
                                       OR g.FirstName LIKE '%' + @search + '%'
                                       OR g.LastName LIKE '%' + @search + '%'
                                       OR p.PaymentMethod LIKE '%' + @search + '%'
                                       OR p.PaymentStatus LIKE '%' + @search + '%')
                                ORDER BY p.PaymentDate DESC";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@search", (object)search ?? DBNull.Value);
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                    return dt;
                }
            }
        }

        public List<KeyValuePair<int, string>> GetReservationLookup()
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT res.ReservationID, res.ReservationCode + ' - ' + g.FirstName + ' ' + g.LastName AS Label
                  FROM Reservations res
                  JOIN Guests g ON g.GuestID = res.GuestID
                  WHERE res.Status NOT IN ('CANCELLED')
                  ORDER BY res.ReservationID DESC", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KeyValuePair<int, string>((int)reader["ReservationID"], reader["Label"] as string));
                    }
                }
            }
            return list;
        }

        public int Insert(Payment p)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Payments (ReservationID, Amount, PaymentMethod, PaymentType, TransactionReference, PaymentStatus, ReceivedBy)
                  OUTPUT INSERTED.PaymentID
                  VALUES (@ReservationID, @Amount, @PaymentMethod, @PaymentType, @TransactionReference, @PaymentStatus, @ReceivedBy)", conn))
            {
                AddCommonParams(cmd, p);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(Payment p)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Payments SET
                    ReservationID = @ReservationID, Amount = @Amount, PaymentMethod = @PaymentMethod,
                    PaymentType = @PaymentType, TransactionReference = @TransactionReference,
                    PaymentStatus = @PaymentStatus
                  WHERE PaymentID = @PaymentID", conn))
            {
                AddCommonParams(cmd, p);
                cmd.Parameters.AddWithValue("@PaymentID", p.PaymentID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int paymentId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Payments WHERE PaymentID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", paymentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void AddCommonParams(SqlCommand cmd, Payment p)
        {
            cmd.Parameters.AddWithValue("@ReservationID", p.ReservationID);
            cmd.Parameters.AddWithValue("@Amount", p.Amount);
            cmd.Parameters.AddWithValue("@PaymentMethod", p.PaymentMethod ?? "CASH");
            cmd.Parameters.AddWithValue("@PaymentType", p.PaymentType ?? "ROOM_PAYMENT");
            cmd.Parameters.AddWithValue("@TransactionReference", (object)p.TransactionReference ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PaymentStatus", p.PaymentStatus ?? "COMPLETED");
            cmd.Parameters.AddWithValue("@ReceivedBy", (object)p.ReceivedBy ?? DBNull.Value);
        }
    }
}
