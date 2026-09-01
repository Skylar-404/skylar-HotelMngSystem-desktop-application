using hotelmngsystem.Database;
using hotelmngsystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    /// <summary>
    /// Data access for the Guests table. Uses plain ADO.NET (SqlCommand/SqlDataAdapter)
    /// through the shared Dbconnection helper, the same way the rest of the DAL layer works.
    /// </summary>
    public class GuestDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        public DataTable GetGuests(string search = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT GuestID, FirstName, LastName, Gender, Phone, Email,
                                       Address, IDNumber, Nationality, Status, CreatedAt
                                FROM Guests
                                WHERE (@search IS NULL OR @search = ''
                                       OR FirstName LIKE '%' + @search + '%'
                                       OR LastName LIKE '%' + @search + '%'
                                       OR Phone LIKE '%' + @search + '%'
                                       OR Email LIKE '%' + @search + '%'
                                       OR IDNumber LIKE '%' + @search + '%')
                                ORDER BY GuestID DESC";

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

        public Guest GetById(int guestId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT GuestID, FirstName, LastName, Gender, Phone, Email,
                         Address, IDNumber, Nationality, Status, CreatedAt, UpdatedAt
                  FROM Guests WHERE GuestID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", guestId);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Map(reader);
                    }
                }
            }
            return null;
        }

        public int Insert(Guest guest)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Guests (FirstName, LastName, Gender, Phone, Email, Address, IDNumber, Nationality, Status)
                  OUTPUT INSERTED.GuestID
                  VALUES (@FirstName, @LastName, @Gender, @Phone, @Email, @Address, @IDNumber, @Nationality, @Status)", conn))
            {
                AddCommonParams(cmd, guest);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(Guest guest)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE Guests SET
                    FirstName = @FirstName, LastName = @LastName, Gender = @Gender,
                    Phone = @Phone, Email = @Email, Address = @Address,
                    IDNumber = @IDNumber, Nationality = @Nationality, Status = @Status,
                    UpdatedAt = SYSDATETIME()
                  WHERE GuestID = @GuestID", conn))
            {
                AddCommonParams(cmd, guest);
                cmd.Parameters.AddWithValue("@GuestID", guest.GuestID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int guestId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Guests WHERE GuestID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", guestId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool HasReservations(int guestId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(1) FROM Reservations WHERE GuestID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", guestId);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void AddCommonParams(SqlCommand cmd, Guest guest)
        {
            cmd.Parameters.AddWithValue("@FirstName", guest.FirstName ?? "");
            cmd.Parameters.AddWithValue("@LastName", guest.LastName ?? "");
            cmd.Parameters.AddWithValue("@Gender", (object)guest.Gender ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", (object)guest.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object)guest.Email ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", (object)guest.Address ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@IDNumber", (object)guest.IDNumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Nationality", (object)guest.Nationality ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", guest.Status ?? "ACTIVE");
        }

        private Guest Map(SqlDataReader reader)
        {
            return new Guest
            {
                GuestID = (int)reader["GuestID"],
                FirstName = reader["FirstName"] as string,
                LastName = reader["LastName"] as string,
                Gender = reader["Gender"] as string,
                Phone = reader["Phone"] as string,
                Email = reader["Email"] as string,
                Address = reader["Address"] as string,
                IDNumber = reader["IDNumber"] as string,
                Nationality = reader["Nationality"] as string,
                Status = reader["Status"] as string,
                CreatedAt = reader["CreatedAt"] as DateTime? ?? DateTime.MinValue,
                UpdatedAt = reader["UpdatedAt"] as DateTime? ?? DateTime.MinValue
            };
        }
    }
}
