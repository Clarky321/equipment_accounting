using System;
using System.Collections.Generic;
using MySqlConnector;

namespace equipment_accounting
{
    // Класс для работы с учетными записями пользователей.
    public class UserLogins : IDisposable
    {
        private readonly string connectionString;

        // Конструктор класса UserLogins.
        public UserLogins(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Список уникальных логинов пользователей.
        public List<string> GetUniqueUserLogins()
        {
            List<string> logins = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT DISTINCT login_user FROM register WHERE login_user IS NOT NULL";

                connection.Open();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0)) // Проверка на NULL значение.
                        {
                            string login = reader.GetString(0);
                            if (!string.IsNullOrEmpty(login))
                            {
                                logins.Add(login);
                            }
                        }
                    }
                }
            }
            return logins;
        }

        // Освобождение ресурсов, занятых объектом UserLogins.
        public void Dispose()
        {
            // Если в будущем потребуется освобождение ресурсов, то метод требуется доработать.
        }
    }
}