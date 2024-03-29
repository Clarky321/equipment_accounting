using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace equipment_accounting
{
    // Класс для работы с базой данных.
    class DataBase : IDisposable
    {
        private readonly string connectionString; // Строка подключения к базе данных.
        private SqlConnection sqlConnection; // Объект SqlConnection для управления соединением с базой данных.
        //public SqlConnection sqlConnection {  get; private set; }

        // Конструктор класса. Инициализирует новый экземпляр класса DataBase с указанной строкой подключения.
        public DataBase(string connectionString)
        {
            // Получаем строку подключения к базе данных из файла конфигурации App.config по имени "MyConnectionStringSql".
            connectionString = ConfigurationManager.ConnectionStrings["MyConnectionStringSql"].ConnectionString;
            // Инициализируем поле connectionString этой строкой.
            this.connectionString = connectionString;
            // Инициализируем объект SqlConnection с использованием строки подключения.
            sqlConnection = new SqlConnection(connectionString);
        }

        // класс UserLogins
        public List<string> GetUniqueUserLogins()
        {
            using (UserLogins userLogins = new UserLogins(connectionString))
            {
                return userLogins.GetUniqueUserLogins();
            }
        }

        // Открывает соединение с базой данных.
        public void openConnection()
        {
            // Проверяем состояние соединения. Если оно закрыто, открываем соединение.
            if (sqlConnection.State == System.Data.ConnectionState.Closed) 
            {
                sqlConnection.Open();
            }
        }
        // Закрывает соединение с базой данных.
        public void closeConnection() 
        {
            // Проверяем состояние соединения. Если оно открыто, закрываем соединение.
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        // Метод для выполнения запроса к базе данных с возвращением объекта SqlCommand.
        // query = SQL запрос.
        // Объект SqlCommand.
        public SqlCommand ExecuteQuery(string query)
        {
            // Открываем соединение с базой данных.
            openConnection();
            // Создаем новый объект SqlCommand с указанным SQL запросом и соединением.
            SqlCommand command = new SqlCommand(query, sqlConnection);
            // Возвращаем объект SqlCommand.
            return command;
        }

        // Метод для выполнения запроса к базе данных без возвращения результата.
        // query = SQL запрос.
        public void ExecuteNonQuery(string query)
        {
            // Открываем соединение с базой данных.
            openConnection();
            // Создаем новый объект SqlCommand с указанным SQL запросом и соединением.
            SqlCommand command = new SqlCommand(query, sqlConnection);
            // Выполняем SQL запрос без возвращения результата.
            command.ExecuteNonQuery();
        }

        // Освобождает ресурсы, используемые объектом DataBase.
        public void Dispose()
        {
            // Проверяем, не равен ли объект sqlConnection null.
            if (sqlConnection != null)
            {
                // Освобождаем ресурсы, связанные с объектом sqlConnection.
                sqlConnection.Dispose();
                // Присваиваем null полю sqlConnection.
                sqlConnection = null;
            }
        }
        // Проверяет, открыто ли соединение с базой данных.
        // True, если соединение открыто, в противном случае - false.
        public bool IsConnectionOpen()
        {
            // Возвращает true, если состояние соединения равно Open, иначе - false.
            return sqlConnection.State == System.Data.ConnectionState.Open;
        }
    }
}