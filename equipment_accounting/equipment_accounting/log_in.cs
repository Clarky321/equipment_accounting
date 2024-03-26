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
    public partial class log_in : Form
    {
        DataBase db = new DataBase();
        sign_up Sign_UpForm;

        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            //Sign_UpForm = new sign_up();

            //Sign_UpForm.AccountCreated += Sign_up_AccountCreated;
        }

        private void Sign_up_AccountCreated(object sender, string e)
        {
            comboBox_login.Items.Add(e);
        }

        private void log_in_Load(object sender, EventArgs e)
        {
            comboBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            var loginUser = comboBox_login.Text;
            var passwordUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"SELECT id_user, login_user FROM register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1) 
            {
                MessageBox.Show("Вы успешно вошли", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                date1 frm2 = new date1();
                Hide();
                frm2.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("Такого аккаунта не существует", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.ShowDialog();
            Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Sign_UpForm = new sign_up();
            Sign_UpForm.AccountCreated += Sign_up_AccountCreated;
            //sign_up sign_Up = new sign_up();
            Hide();
            Sign_UpForm.ShowDialog();
            Show();
        }
    }
}
