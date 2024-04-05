using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace equipment_accounting
{
    public class UserLogins : IDisposable
    {
        private readonly string connectionString;

        public UserLogins(string MyConnectionStringSql)
        {
            connectionString = MyConnectionStringSql;
        }

        public List<string> GetUniqueUserLogins()
        {
            List<string> logins = new List<string>();

            string query = "SELECT DISTINCT login_user FROM register";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string login = reader.GetString(0);
                            logins.Add(login);
                        }
                    }
                }
            }

            return logins;
        }

        public void Dispose()
        {
            
        }
    }
}
