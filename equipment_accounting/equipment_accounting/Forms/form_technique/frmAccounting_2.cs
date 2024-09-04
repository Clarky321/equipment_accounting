using System;
using System.Data;
using System.Windows.Forms;
using MySqlConnector;

namespace equipment_accounting
{
    public partial class frmAccounting_2 : Form
    {
        private DataBase db;

        public frmAccounting_2(bool isAdmin)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void frmAccounting_2_Load(object sender, EventArgs e)
        {
            LoadYears();
            LoadMonth();
        }

        private void DataGirdSize()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void HeaderText()
        {
            if (dataGridView1.Columns.Contains("dates"))
            {
                dataGridView1.Columns["dates"].HeaderText = "Дата";
                dataGridView1.Columns["dates"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            if (dataGridView1.Columns.Contains("names"))
            {
                dataGridView1.Columns["names"].HeaderText = "Ответственный";
            }

            if (dataGridView1.Columns.Contains("message"))
            {
                dataGridView1.Columns["message"].HeaderText = "Сообщение";
            }
        }

        private void UpdateDataGridView()
        {
            try
            {
                int year = int.Parse(comboBox_year.Text);
                int month = comboBox_month.SelectedIndex + 1;

                string query = $"SELECT dates, names, message FROM technique_night WHERE YEAR(dates) = {year} AND MONTH(dates) = {month}";
                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                DataGirdSize();
                HeaderText();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении данных: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadYears()
        {
            try
            {
                string query = "SELECT DISTINCT YEAR(dates) AS Year FROM technique_night";
                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                comboBox_year.DisplayMember = "Year";
                comboBox_year.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке годов из базы данных: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonth()
        {
            try
            {
                comboBox_month.Items.AddRange(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке месяцев: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void comboBox_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            UpdateDataGridView();
        }

        private void frmMenu_Resize(object sender, EventArgs e)
        {
            float widthRatio = (float)Width / MinimumSize.Width;

            float heightRatio = (float)Height / MinimumSize.Height;

            foreach (Control control in Controls)
            {
                control.Left = (int)(control.Left * widthRatio);
                control.Top = (int)(control.Top * heightRatio);
                control.Width = (int)(control.Width * widthRatio);
                control.Height = (int)(control.Height * heightRatio);
            }
        }
    }
}