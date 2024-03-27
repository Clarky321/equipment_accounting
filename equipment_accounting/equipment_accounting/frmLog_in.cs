using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace equipment_accounting
{
    public partial class frmLog_in : Form
    {
        private DataBase db;

        public frmLog_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");
        }

        private void frmLog_in_Load(object sender, EventArgs e)
        {
            btnCombo_login.MaxLength = 50;
            btnText_password.MaxLength = 50;

            ComboBoxUserLogins();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string loginUser = btnCombo_login.Text;
            string passwordUser = btnText_password.Text;

            string query = $"SELECT * FROM register WHERE login_user = '{loginUser}' AND password_user = '{passwordUser}'";

            try
            {
                var command = db.ExecuteQuery(query);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    MessageBox.Show("Вы вошли в систему", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Hide();
                    date1 frmDate1 = new date1();
                    frmDate1.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                db.closeConnection();
            }
        }

        // Метод для заполнения ComboBox логинами из базы данных.
        private void ComboBoxUserLogins()
        {
            try
            {
                // Получаем список уникальных логинов из базы данных.
                List<string> logins = db.GetUniqueUserLogins();

                btnCombo_login.Items.Clear();

                // Добавляем каждый логин в ComboBox.
                foreach (string login in logins)
                {
                    btnCombo_login.Items.Add(login);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке логинов: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AccountRegLabel_Click(object sender, EventArgs e)
        {
            frmSign_up sign_Up = new frmSign_up();
            Hide();
            sign_Up.ShowDialog();
            Show();
        }
    }
}