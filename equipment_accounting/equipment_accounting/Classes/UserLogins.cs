using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace equipment_accounting
{
    // Класс для работы с учетными записями пользователей
    public class UserLogins : IDisposable
    {
        private readonly string connectionString;

        // Конструктор класса UserLogins
        public UserLogins(string connectionString)
        {
            this.connectionString = connectionString;
        }
        // Список уникальных логинов пользователей
        public List<string> GetUniqueUserLogins()
        {
            // Создание нового списка для хранения уникальных логинов пользователей
            List<string> logins = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            using (MySqlCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT DISTINCT login_user FROM register";

                connection.Open();
                // Выполнеине SQL - запроса и получение результатов в виде DataReader
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Перебор всех записей в результирующем наборе
                    while (reader.Read())
                    {
                        // Получение логина пользователя из текущей записи и добавление его в список
                        logins.Add(reader.GetString(0));
                    }
                }
            }
            // Возвращение списка уникальных логинов пользователей
            return logins;
        }

        // Освобождение ресурсов, занятые объектом UserLogins
        public void Dispose()
        {
            // Если в будущем потребуется освобождение ресурсов, то метод требуется доработать
        }
    }
}
