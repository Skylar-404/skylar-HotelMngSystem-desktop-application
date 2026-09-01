using hotelmngsystem.Database;
using hotelmngsystem.Helpers;
using hotelmngsystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    public class UserDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        /// <summary>
        /// Validates credentials against the Users table. Returns the matching
        /// active user, or null if the username/password is invalid.
        /// </summary>
        public User Authenticate(string username, string plainPassword)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT UserID, Username, PasswordHash, FullName, Role, Phone, Email, Status, CreatedAt, UpdatedAt
                  FROM Users WHERE Username = @u AND Status = 'ACTIVE'", conn))
            {
                cmd.Parameters.AddWithValue("@u", username ?? "");
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash = reader["PasswordHash"] as string;
                        if (PasswordHelper.Verify(plainPassword, storedHash))
                        {
                            return Map(reader);
                        }
                    }
                }
            }
            return null;
        }

        public DataTable GetUsers(string search = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT UserID, Username, FullName, Role, Phone, Email, Status, CreatedAt
                                FROM Users
                                WHERE (@search IS NULL OR @search = ''
                                       OR Username LIKE '%' + @search + '%'
                                       OR FullName LIKE '%' + @search + '%'
                                       OR Role LIKE '%' + @search + '%')
                                ORDER BY UserID DESC";
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

        public User GetById(int userId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT UserID, Username, PasswordHash, FullName, Role, Phone, Email, Status, CreatedAt, UpdatedAt
                  FROM Users WHERE UserID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) return Map(reader);
                }
            }
            return null;
        }

        public bool UsernameExists(string username, int? excludeUserId = null)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(1) FROM Users WHERE Username = @u AND (@excludeId IS NULL OR UserID <> @excludeId)", conn))
            {
                cmd.Parameters.AddWithValue("@u", username ?? "");
                cmd.Parameters.AddWithValue("@excludeId", (object)excludeUserId ?? DBNull.Value);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int Insert(User user)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Users (Username, PasswordHash, FullName, Role, Phone, Email, Status)
                  OUTPUT INSERTED.UserID
                  VALUES (@Username, @PasswordHash, @FullName, @Role, @Phone, @Email, @Status)", conn))
            {
                cmd.Parameters.AddWithValue("@Username", user.Username ?? "");
                cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash ?? "");
                cmd.Parameters.AddWithValue("@FullName", user.FullName ?? "");
                cmd.Parameters.AddWithValue("@Role", user.Role ?? "EMPLOYEE");
                cmd.Parameters.AddWithValue("@Phone", (object)user.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", user.Status ?? "ACTIVE");
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>Updates profile fields. Pass a non-empty PasswordHash to also change the password.</summary>
        public void Update(User user, bool changePassword)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = changePassword
                    ? @"UPDATE Users SET Username = @Username, PasswordHash = @PasswordHash, FullName = @FullName,
                            Role = @Role, Phone = @Phone, Email = @Email, Status = @Status, UpdatedAt = SYSDATETIME()
                        WHERE UserID = @UserID"
                    : @"UPDATE Users SET Username = @Username, FullName = @FullName,
                            Role = @Role, Phone = @Phone, Email = @Email, Status = @Status, UpdatedAt = SYSDATETIME()
                        WHERE UserID = @UserID";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username ?? "");
                    if (changePassword)
                        cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash ?? "");
                    cmd.Parameters.AddWithValue("@FullName", user.FullName ?? "");
                    cmd.Parameters.AddWithValue("@Role", user.Role ?? "EMPLOYEE");
                    cmd.Parameters.AddWithValue("@Phone", (object)user.Phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)user.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", user.Status ?? "ACTIVE");
                    cmd.Parameters.AddWithValue("@UserID", user.UserID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int userId)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private User Map(SqlDataReader reader)
        {
            return new User
            {
                UserID = (int)reader["UserID"],
                Username = reader["Username"] as string,
                PasswordHash = reader["PasswordHash"] as string,
                FullName = reader["FullName"] as string,
                Role = reader["Role"] as string,
                Phone = reader["Phone"] as string,
                Email = reader["Email"] as string,
                Status = reader["Status"] as string,
                CreatedAt = reader["CreatedAt"] as DateTime? ?? DateTime.MinValue,
                UpdatedAt = reader["UpdatedAt"] as DateTime? ?? DateTime.MinValue
            };
        }
    }
}
