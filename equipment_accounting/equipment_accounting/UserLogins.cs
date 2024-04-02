using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace equipment_accounting
{
    public class UserLogins : IDisposable
    {
        private readonly string connectionString;

        public UserLogins(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<string> GetUniqueUserLogins()
        {
            List<string> logins = new List<string>();

            string query = "SELECT DISTINCT login_user FROM register";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
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
