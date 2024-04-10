using System;
using System.Windows.Forms;

namespace equipment_accounting
{
    public partial class frmSign_up : Form
    {
        private DataBase db;

        public frmSign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");
        }

        private void frmSign_up_Load(object sender, EventArgs e)
        {
            btnText_login.MaxLength = 50;
            btnText_password.MaxLength = 50;

            comboBox_isAdmin.Items.Add("Пользователь");
            comboBox_isAdmin.Items.Add("Администратор");
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string userLogin = btnText_login.Text;
            string userPassword = btnText_password.Text;
            bool isAdmin = (comboBox_isAdmin.SelectedIndex == 1);

            if (string.IsNullOrEmpty(userLogin) || string.IsNullOrEmpty(userPassword)) 
            {
                MessageBox.Show("Введите логин и пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия такого логина в базе данных
            if (IsLoginUnique(userLogin))
            {
                // Если логин уникален, регистрируем аккаунт
                RegisterAccount(userLogin, userPassword, isAdmin);
            }
            else
            {
                MessageBox.Show("Логин с таким именем уже существует.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsLoginUnique(string userLogin)
        {
            string query = $"SELECT COUNT(*) FROM register WHERE login_user = '{userLogin}'";

            int count = 0;

            try
            {
                var command = db.ExecuteQuery(query);
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Если количество записей с таким логином равно 0, то логин уникален
            return count == 0;
        }

        private void RegisterAccount(string userLogin, string userPassword, bool isAdmin)
        {
            string isAdminString = isAdmin ? "Администратор" : "Пользователь"; // Преобразуем булевое значение в строковое значение

            string query = $"INSERT INTO register (login_user, password_user, isAdmin) VALUES ('{userLogin}', '{userPassword}', '{isAdminString}')";

            try
            {
                db.ExecuteNonQuery(query);

                MessageBox.Show("Регистрация успешно завершена", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}