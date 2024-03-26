using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace equipment_accounting
{
    public partial class sign_up : Form
    {
        DataBase db = new DataBase();

        public event EventHandler<string> AccountCreated;

        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void log_in_Load(object sender, EventArgs e)
        {

        }

        private void btn_auth_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passwordUser = textBox_password.Text;

            string querystring = $"INSERT INTO register(login_user, password_user) values ('{loginUser}', '{passwordUser}')";

            SqlCommand command = new SqlCommand(querystring, db.GetConnection());

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан", "Успех");

                AccountCreated?.Invoke(this, loginUser);

                log_in frm_login = new log_in();
                Hide();
                frm_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Аккаунт не создан");
            }

            db.closeConnection();
        }

        private Boolean checkuser()
        {
            var login = textBox_login.Text;
            var password = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"SELECT id_user, login_user, password_user FROM register where login_user = '{login}' and password_user = '{password}'";

            SqlCommand command = new SqlCommand(querystring , db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0) 
            {
                MessageBox.Show("Пользователь уже существует");

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
