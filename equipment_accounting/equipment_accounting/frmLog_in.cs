using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace equipment_accounting
{
    public partial class frmLog_in : Form
    {
        private DataBase db;

        public event EventHandler SuccessfulLogin;

        public frmLog_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");
        }

        private void frmLog_in_Load(object sender, EventArgs e)
        {
            SetMaxLengths();
            LoadUserLogins();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            // Получаем логин и пароль пользователя
            string loginUser = btnCombo_login.Text;
            string passwordUser = btnText_password.Text;

            // Создаем SQL запрос для проверки авторизации пользователя
            string query = $"SELECT * FROM register WHERE login_user = '{loginUser}' AND password_user = '{passwordUser}'";

            try
            {
                // Выполняем запрос к базе данных
                var command = db.ExecuteQuery(query);

                // Читаем результат выполнения запроса
                SqlDataReader reader = command.ExecuteReader();

                // Если найдены записи, то авторизация успешна
                if (reader.HasRows)
                {
                    // Выводим сообщение об успешной авторизации
                    MessageBox.Show("Вы вошли в систему", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SuccessfulLogin?.Invoke(this, new EventArgs());
                }
                // Иначе выводим сообщение о неверных данных
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Закрываем соединение с базой данных
                db.closeConnection();
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение с ошибкой
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Закрываем соединение с базой данных
                db.closeConnection();
            }
        }

        // Метод для установки максимальной длины текстовых полей
        private void SetMaxLengths()
        {
            btnCombo_login.MaxLength = 50;
            btnText_password.MaxLength = 50;
        }

        // Метод для загрузки логинов пользователей в выпадающий список
        private void LoadUserLogins()
        {
            try
            {
                List<string> logins = db.GetUniqueUserLogins();

                btnCombo_login.Items.AddRange(logins.ToArray());
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ошибка при загрузке логинов: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Выходим из приложения
            Application.Exit();
        }
    }
}