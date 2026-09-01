using hotelmngsystem.Database;
using hotelmngsystem.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace hotelmngsystem.DAL
{
    public class RoomTypeDAL
    {
        private readonly Dbconnection db = new Dbconnection();

        public List<RoomType> GetAll()
        {
            List<RoomType> list = new List<RoomType>();

            using (SqlConnection conn = db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT RoomTypeID, TypeName, Description, Capacity, BasePrice, Status " +
                "FROM RoomTypes WHERE Status = 'ACTIVE' ORDER BY TypeName", conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new RoomType
                        {
                            RoomTypeID = (int)reader["RoomTypeID"],
                            TypeName = reader["TypeName"] as string,
                            Description = reader["Description"] as string,
                            Capacity = (int)reader["Capacity"],
                            BasePrice = (decimal)reader["BasePrice"],
                            Status = reader["Status"] as string
                        });
                    }
                }
            }
            return list;
        }
    }
}
