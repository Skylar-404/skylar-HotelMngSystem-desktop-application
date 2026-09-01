using hotelmngsystem.Database;
using hotelmngsystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    public class RoomDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        public DataTable GetRooms(string search = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT r.RoomID, r.RoomNumber, rt.TypeName, r.FloorNumber, r.Status, rt.BasePrice
                                FROM Rooms r
                                JOIN RoomTypes rt ON rt.RoomTypeID = r.RoomTypeID
                                WHERE (@search IS NULL OR @search = ''
                                       OR r.RoomNumber LIKE '%' + @search + '%'
                                       OR rt.TypeName LIKE '%' + @search + '%'
                                       OR r.Status LIKE '%' + @search + '%')
                                ORDER BY r.RoomNumber";

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

        public List<Room> GetAvailableRooms(int? includeRoomId = null)
        {
            List<Room> list = new List<Room>();
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT r.RoomID, r.RoomNumber, r.RoomTypeID, rt.TypeName, rt.BasePrice, r.FloorNumber, r.Status
                  FROM Rooms r
                  JOIN RoomTypes rt ON rt.RoomTypeID = r.RoomTypeID
                  WHERE r.Status = 'AVAILABLE' OR r.RoomID = @includeId
                  ORDER BY r.RoomNumber", conn))
            {
                cmd.Parameters.AddWithValue("@includeId", (object)includeRoomId ?? 0);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapReader(reader));
                    }
                }
            }
            return list;
        }

        public List<Room> GetAllRooms()
        {
            List<Room> list = new List<Room>();
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT r.RoomID, r.RoomNumber, r.RoomTypeID, rt.TypeName, rt.BasePrice, r.FloorNumber, r.Status
                  FROM Rooms r
                  JOIN RoomTypes rt ON rt.RoomTypeID = r.RoomTypeID
                  ORDER BY r.RoomNumber", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapReader(reader));
                    }
                }
            }
            return list;
        }

        public Room GetById(int roomId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT r.RoomID, r.RoomNumber, r.RoomTypeID, rt.TypeName, rt.BasePrice, r.FloorNumber, r.Status
                  FROM Rooms r JOIN RoomTypes rt ON rt.RoomTypeID = r.RoomTypeID
                  WHERE r.RoomID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", roomId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return MapReader(reader);
                }
            }
            return null;
        }

        public int Insert(Room room)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Rooms (RoomNumber, RoomTypeID, FloorNumber, Status)
                  OUTPUT INSERTED.RoomID
                  VALUES (@RoomNumber, @RoomTypeID, @FloorNumber, @Status)", conn))
            {
                cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber ?? "");
                cmd.Parameters.AddWithValue("@RoomTypeID", room.RoomTypeID);
                cmd.Parameters.AddWithValue("@FloorNumber", (object)room.FloorNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", room.Status ?? "AVAILABLE");
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(Room room)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Rooms SET RoomNumber = @RoomNumber, RoomTypeID = @RoomTypeID,
                    FloorNumber = @FloorNumber, Status = @Status
                  WHERE RoomID = @RoomID", conn))
            {
                cmd.Parameters.AddWithValue("@RoomNumber", room.RoomNumber ?? "");
                cmd.Parameters.AddWithValue("@RoomTypeID", room.RoomTypeID);
                cmd.Parameters.AddWithValue("@FloorNumber", (object)room.FloorNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", room.Status ?? "AVAILABLE");
                cmd.Parameters.AddWithValue("@RoomID", room.RoomID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStatus(int roomId, string newStatus)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Rooms SET Status = @Status WHERE RoomID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@id", roomId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int roomId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Rooms WHERE RoomID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", roomId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool HasReservations(int roomId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(1) FROM Reservations WHERE RoomID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", roomId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private Room MapReader(SqlDataReader reader)
        {
            return new Room
            {
                RoomID = (int)reader["RoomID"],
                RoomNumber = reader["RoomNumber"] as string,
                RoomTypeID = (int)reader["RoomTypeID"],
                TypeName = reader["TypeName"] as string,
                BasePrice = (decimal)reader["BasePrice"],
                FloorNumber = reader["FloorNumber"] as int?,
                Status = reader["Status"] as string
            };
        }
    }
}
