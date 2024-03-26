using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace equipment_accounting
{
    class DataBase
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-NQGEV7V\IBDASERVER;Initial Catalog=base1; Integrated Security=True");

        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed) 
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection() 
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection() 
        {
            return sqlConnection;
        }

        public bool IsConnectionOpen()
        {
            return sqlConnection.State == System.Data.ConnectionState.Open;
        }
    }
}
