using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CustomerJust.Repository
{
    public class ConnectionRepository
    {
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;

        public void CreateConnectionAndMakeSqlCommand(string queryString)
        {

            string connectionString = @"Server=ROBINHOOD\MARUFROBINSQL; Database=JustCustomers; Integrated Security = True";
            sqlConnection = new SqlConnection(connectionString);

        }

        public void ExecuteNonQuery()
        {
            sqlConnection.Open();

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public SqlDataReader ExecuteQuery()
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            sqlConnection.Close();

            return sqlDataReader;
        }
    }
}
