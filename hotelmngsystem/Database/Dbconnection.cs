using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace hotelmngsystem.Database
{
    internal class Dbconnection
    {
        private string connectionString = "Server=.\\SQLEXPRESS;Database=HotelSystem;User Id=[user_id];Password=[user_pwd];";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
