using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            string userLogin = btnText_login.Text;
            string userPassword = btnText_password.Text;

            if (string.IsNullOrEmpty(userLogin) || string.IsNullOrEmpty(userPassword)) 
            {
                MessageBox.Show("Введите логин и пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка наличия такого логина в базе данных
            if (IsLoginUnique(userLogin))
            {
                // Если логин уникален, регистрируем аккаунт
                RegisterAccount(userLogin, userPassword);
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

        private void RegisterAccount(string userLogin, string userPassword)
        {
            string query = $"INSERT INTO register (login_user, password_user) VALUES ('{userLogin}', '{userPassword}')";

            try
            {
                db.ExecuteNonQuery(query);

                MessageBox.Show("Регистрация успешно завершена", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmLog_in log_In = new frmLog_in();
                log_In.ShowDialog();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountAuthLabel_Click(object sender, EventArgs e)
        {
            frmLog_in log_In = new frmLog_in();
            Hide();
            log_In.ShowDialog();
            Show();
        }
    }
}