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
    public partial class frmAdmin_panel : Form
    {
        private DataBase db;

        public frmAdmin_panel()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            // Инициализируем экземпляр класса DataBase с помощью строки подключения из файла конфигурации
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionStringSql"].ConnectionString;
            db = new DataBase(connectionString);
        }

        // Вывод в Log Console
        private void AddLog(string message)
        {
            textBoxConsole.AppendText(message + Environment.NewLine);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();

                if (db.IsConnectionOpen())
                {
                    //MessageBox.Show("Подключение к базе данных установлено", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AddLog("Log: Подключение к базе данных успешно установлено");
                }
                else
                {
                    //MessageBox.Show("Не удалось установить подключение к базе данных", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AddLog("Log: Не удалось установить подключение к базе данных");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при попытке подключения к базе данных: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
