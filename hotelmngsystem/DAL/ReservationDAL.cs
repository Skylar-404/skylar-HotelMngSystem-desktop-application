using hotelmngsystem.Database;
using hotelmngsystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    public class ReservationDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        public DataTable GetReservations(string search = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT res.ReservationID, res.ReservationCode,
                                       g.FirstName + ' ' + g.LastName AS Guest,
                                       rm.RoomNumber AS Room,
                                       res.CheckInDate, res.CheckOutDate,
                                       res.Adults, res.Children, res.RoomRate, res.Status
                                FROM Reservations res
                                JOIN Guests g ON g.GuestID = res.GuestID
                                JOIN Rooms rm ON rm.RoomID = res.RoomID
                                WHERE (@search IS NULL OR @search = ''
                                       OR res.ReservationCode LIKE '%' + @search + '%'
                                       OR g.FirstName LIKE '%' + @search + '%'
                                       OR g.LastName LIKE '%' + @search + '%'
                                       OR rm.RoomNumber LIKE '%' + @search + '%'
                                       OR res.Status LIKE '%' + @search + '%')
                                ORDER BY res.ReservationID DESC";
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

        public Reservation GetById(int reservationId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT res.*, g.FirstName + ' ' + g.LastName AS GuestName, rm.RoomNumber
                  FROM Reservations res
                  JOIN Guests g ON g.GuestID = res.GuestID
                  JOIN Rooms rm ON rm.RoomID = res.RoomID
                  WHERE res.ReservationID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", reservationId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return Map(reader);
                }
            }
            return null;
        }

        public int Insert(Reservation r)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Reservations
                    (ReservationCode, GuestID, RoomID, CheckInDate, CheckOutDate, Adults, Children,
                     RoomRate, Status, SpecialRequest, CreatedBy)
                  OUTPUT INSERTED.ReservationID
                  VALUES
                    (@ReservationCode, @GuestID, @RoomID, @CheckInDate, @CheckOutDate, @Adults, @Children,
                     @RoomRate, @Status, @SpecialRequest, @CreatedBy)", conn))
            {
                AddCommonParams(cmd, r);
                cmd.Parameters.AddWithValue("@ReservationCode", r.ReservationCode ?? GenerateCode());
                conn.Open();
                int newId = (int)cmd.ExecuteScalar();

                // If a room is reserved right away, mark it as RESERVED so it drops out of the available list.
                if (r.Status == "CONFIRMED" || r.Status == "PENDING")
                {
                    UpdateRoomStatus(conn, r.RoomID, "RESERVED");
                }
                return newId;
            }
        }

        public void Update(Reservation r)
        {
            string previousStatus;
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();

                using (SqlCommand getCmd = new SqlCommand("SELECT Status FROM Reservations WHERE ReservationID = @id", conn))
                {
                    getCmd.Parameters.AddWithValue("@id", r.ReservationID);
                    object result = getCmd.ExecuteScalar();
                    previousStatus = result?.ToString();
                }

                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE Reservations SET
                        GuestID = @GuestID, RoomID = @RoomID, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate,
                        Adults = @Adults, Children = @Children, RoomRate = @RoomRate, Status = @Status,
                        SpecialRequest = @SpecialRequest, UpdatedAt = SYSDATETIME()
                      WHERE ReservationID = @ReservationID", conn))
                {
                    AddCommonParams(cmd, r);
                    cmd.Parameters.AddWithValue("@ReservationID", r.ReservationID);
                    cmd.ExecuteNonQuery();
                }

                // Keep the room's status roughly in sync with the reservation lifecycle.
                if (previousStatus != r.Status)
                {
                    switch (r.Status)
                    {
                        case "CHECKED_IN":
                            UpdateRoomStatus(conn, r.RoomID, "OCCUPIED");
                            break;
                        case "CHECKED_OUT":
                            UpdateRoomStatus(conn, r.RoomID, "DIRTY");
                            break;
                        case "CONFIRMED":
                        case "PENDING":
                            UpdateRoomStatus(conn, r.RoomID, "RESERVED");
                            break;
                        case "CANCELLED":
                        case "NO_SHOW":
                            UpdateRoomStatus(conn, r.RoomID, "AVAILABLE");
                            break;
                    }
                }
            }
        }

        public void Delete(int reservationId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Reservations WHERE ReservationID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", reservationId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool HasPayments(int reservationId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(1) FROM Payments WHERE ReservationID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", reservationId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void UpdateRoomStatus(SqlConnection openConn, int roomId, string status)
        {
            using (SqlCommand cmd = new SqlCommand("UPDATE Rooms SET Status = @s WHERE RoomID = @id", openConn))
            {
                cmd.Parameters.AddWithValue("@s", status);
                cmd.Parameters.AddWithValue("@id", roomId);
                cmd.ExecuteNonQuery();
            }
        }

        private string GenerateCode()
        {
            return "RES" + DateTime.Now.ToString("yyMMddHHmmss");
        }

        private void AddCommonParams(SqlCommand cmd, Reservation r)
        {
            cmd.Parameters.AddWithValue("@GuestID", r.GuestID);
            cmd.Parameters.AddWithValue("@RoomID", r.RoomID);
            cmd.Parameters.AddWithValue("@CheckInDate", r.CheckInDate.Date);
            cmd.Parameters.AddWithValue("@CheckOutDate", r.CheckOutDate.Date);
            cmd.Parameters.AddWithValue("@Adults", r.Adults <= 0 ? 1 : r.Adults);
            cmd.Parameters.AddWithValue("@Children", r.Children < 0 ? 0 : r.Children);
            cmd.Parameters.AddWithValue("@RoomRate", r.RoomRate);
            cmd.Parameters.AddWithValue("@Status", r.Status ?? "PENDING");
            cmd.Parameters.AddWithValue("@SpecialRequest", (object)r.SpecialRequest ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@CreatedBy", (object)r.CreatedBy ?? DBNull.Value);
        }

        private Reservation Map(SqlDataReader reader)
        {
            return new Reservation
            {
                ReservationID = (int)reader["ReservationID"],
                ReservationCode = reader["ReservationCode"] as string,
                GuestID = (int)reader["GuestID"],
                GuestName = reader["GuestName"] as string,
                RoomID = (int)reader["RoomID"],
                RoomNumber = reader["RoomNumber"] as string,
                CheckInDate = (DateTime)reader["CheckInDate"],
                CheckOutDate = (DateTime)reader["CheckOutDate"],
                Adults = (int)reader["Adults"],
                Children = (int)reader["Children"],
                RoomRate = (decimal)reader["RoomRate"],
                Status = reader["Status"] as string,
                SpecialRequest = reader["SpecialRequest"] as string,
                CreatedBy = reader["CreatedBy"] as int?,
                CreatedAt = reader["CreatedAt"] as DateTime? ?? DateTime.MinValue,
                UpdatedAt = reader["UpdatedAt"] as DateTime? ?? DateTime.MinValue
            };
        }
    }
}
