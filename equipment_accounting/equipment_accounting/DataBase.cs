using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace equipment_accounting
{
    // Класс для работы с базой данных.
    class DataBase : IDisposable
    {
        private readonly string connectionString; // Строка подключения к базе данных.
        private MySqlConnection mysqlConnection; // Объект MySqlConnection для управления соединением с базой данных.

        // Конструктор класса. Инициализирует новый экземпляр класса DataBase с указанной строкой подключения.
        public DataBase(string MyConnectionStringSql)
        {
            // Получаем строку подключения к базе данных из файла конфигурации App.config по указанному имени.
            connectionString = ConfigurationManager.ConnectionStrings[MyConnectionStringSql].ConnectionString;
            // Инициализируем объект MySqlConnection с использованием строки подключения.
            mysqlConnection = new MySqlConnection(connectionString);
        }

        public List<string> GetUniqueUserLogins()
        {
            using (UserLogins userLogins = new UserLogins(this.connectionString))
            {
                return userLogins.GetUniqueUserLogins();
            }
        }

        // Открывает соединение с базой данных.
        public void OpenConnection()
        {
            // Проверяем состояние соединения. Если оно закрыто, открываем соединение.
            if (mysqlConnection.State == System.Data.ConnectionState.Closed)
            {
                mysqlConnection.Open();
            }
        }

        // Закрывает соединение с базой данных.
        public void CloseConnection()
        {
            // Проверяем состояние соединения. Если оно открыто, закрываем соединение.
            if (mysqlConnection.State == System.Data.ConnectionState.Open)
            {
                mysqlConnection.Close();
            }
        }

        // Метод для выполнения запроса к базе данных с возвращением объекта MySqlCommand.
        // query = SQL запрос.
        // Объект MySqlCommand.
        public MySqlCommand ExecuteQuery(string query)
        {
            // Открываем соединение с базой данных.
            OpenConnection();
            // Создаем новый объект MySqlCommand с указанным SQL запросом и соединением.
            MySqlCommand command = new MySqlCommand(query, mysqlConnection);
            // Возвращаем объект MySqlCommand.
            return command;
        }

        // Метод для выполнения запроса к базе данных без возвращения результата.
        // query = SQL запрос.
        public void ExecuteNonQuery(string query)
        {
            // Открываем соединение с базой данных.
            OpenConnection();
            // Создаем новый объект MySqlCommand с указанным SQL запросом и соединением.
            MySqlCommand command = new MySqlCommand(query, mysqlConnection);
            // Выполняем SQL запрос без возвращения результата.
            command.ExecuteNonQuery();
        }

        // Освобождает ресурсы, используемые объектом DataBase.
        public void Dispose()
        {
            // Проверяем, не равен ли объект mysqlConnection null.
            if (mysqlConnection != null)
            {
                // Освобождаем ресурсы, связанные с объектом mysqlConnection.
                mysqlConnection.Dispose();
                // Присваиваем null полю mysqlConnection.
                mysqlConnection = null;
            }
        }

        // Проверяет, открыто ли соединение с базой данных.
        // True, если соединение открыто, в противном случае - false.
        public bool IsConnectionOpen()
        {
            // Возвращает true, если состояние соединения равно Open, иначе - false.
            return mysqlConnection != null && mysqlConnection.State == System.Data.ConnectionState.Open;
        }
    }
}