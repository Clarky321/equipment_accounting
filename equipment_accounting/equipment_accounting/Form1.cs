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
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.openConnection();

            if (db.IsConnectionOpen())
            {
                MessageBox.Show("Соединение с базой данных успешно установлено");
            }
            else
            {
                MessageBox.Show("Не удалось установить соединение с базой данных");
            }

            db.closeConnection();
        }
    }
}
