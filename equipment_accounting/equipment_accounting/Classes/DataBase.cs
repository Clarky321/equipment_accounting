using System;
using System.Collections.Generic;
using System.Configuration;
using MySqlConnector;

namespace equipment_accounting
{
    class DataBase : IDisposable
    {
        private readonly string connectionString; // Строка подключения к базе данных.
        private MySqlConnection mysqlConnection; // Объект MySqlConnection для управления соединением с базой данных.

        public DataBase(string MyConnectionStringSql)
        {
            connectionString = ConfigurationManager.ConnectionStrings[MyConnectionStringSql].ConnectionString;
            mysqlConnection = new MySqlConnection(connectionString);
        }

        public MySqlConnection Connection => mysqlConnection;

        public List<string> GetUniqueUserLogins()
        {
            using (UserLogins userLogins = new UserLogins(this.connectionString))
            {
                return userLogins.GetUniqueUserLogins();
            }
        }

        public void OpenConnection()
        {
            if (mysqlConnection.State == System.Data.ConnectionState.Closed)
            {
                mysqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (mysqlConnection.State == System.Data.ConnectionState.Open)
            {
                mysqlConnection.Close();
            }
        }

        public MySqlCommand ExecuteQuery(string query)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, mysqlConnection);
            return command;
        }

        public void ExecuteNonQuery(string query)
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand(query, mysqlConnection);
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            mysqlConnection?.Dispose();
        }

        public bool IsConnectionOpen()
        {
            return mysqlConnection != null && mysqlConnection.State == System.Data.ConnectionState.Open;
        }
    }
}