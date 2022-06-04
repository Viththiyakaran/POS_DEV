using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
   public class SqlHelper
    {
        SqlConnection sqlConnection;

        public SqlHelper(string _connection)
        {
            sqlConnection = new SqlConnection(_connection);
        }

        public bool IsConnection
        {
            get{
            
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();


                return true;
            }
        }
    }
}
