using hotelmngsystem.Database;
using hotelmngsystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    public class RoomOperationDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        public DataTable GetOperations(string search = null)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                string sql = @"SELECT o.OperationID, r.RoomNumber, o.OperationType, o.OldStatus, o.NewStatus,
                                       o.Description, u.FullName AS PerformedByName, o.OperationDate
                                FROM RoomOperations o
                                JOIN Rooms r ON r.RoomID = o.RoomID
                                JOIN Users u ON u.UserID = o.PerformedBy
                                WHERE (@search IS NULL OR @search = ''
                                       OR r.RoomNumber LIKE '%' + @search + '%'
                                       OR o.OperationType LIKE '%' + @search + '%'
                                       OR o.NewStatus LIKE '%' + @search + '%')
                                ORDER BY o.OperationDate DESC";
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

        public void LogOperation(RoomOperation op)
        {
            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO RoomOperations (RoomID, ReservationID, OperationType, OldStatus, NewStatus, Description, PerformedBy)
                  VALUES (@RoomID, @ReservationID, @OperationType, @OldStatus, @NewStatus, @Description, @PerformedBy)", conn))
            {
                cmd.Parameters.AddWithValue("@RoomID", op.RoomID);
                cmd.Parameters.AddWithValue("@ReservationID", (object)op.ReservationID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OperationType", op.OperationType ?? "STATUS_CHANGE");
                cmd.Parameters.AddWithValue("@OldStatus", (object)op.OldStatus ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewStatus", (object)op.NewStatus ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Description", (object)op.Description ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PerformedBy", op.PerformedBy);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
