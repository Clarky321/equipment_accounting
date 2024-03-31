﻿using System;
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
    public partial class frmAccounting_1 : Form
    {
        private DataBase db;

        public frmAccounting_1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");
        }

        private void frmAccounting_1_Load(object sender, EventArgs e)
        {
            //DatesCheck();

            // Загружаем доступные года и месяцы при загрузке формы
            LoadYears();
            LoadMonth();
        }

        private void DataGirdSize()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void HeaderText()
        {
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns["dates"].HeaderText = "Дата";
            dataGridView1.Columns["loptops_1"].HeaderText = "Ноутбуки";
            dataGridView1.Columns["loptops_2"].HeaderText = "Ноутбуки(Зайцев)";
            dataGridView1.Columns["projectors"].HeaderText = "Проекторы";
            dataGridView1.Columns["webcam_logitech"].HeaderText = "Веб-камера Logitech";
            dataGridView1.Columns["webcam_nlo"].HeaderText = "Веб-камера(круглая)";
            dataGridView1.Columns["webcam_tower"].HeaderText = "Веб-камера(башня)";
        }

        private void UpdateDataGridView()
        {
            try
            {
                int year = int.Parse(comboBox_year.Text);
                int month = comboBox_month.SelectedIndex + 1;

                string query = $"SELECT * FROM technique_morning WHERE YEAR(dates) = {year} AND MONTH(dates) = {month}";
                SqlCommand command = db.ExecuteQuery(query);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                HeaderText();
                DataGirdSize();
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
                // Запрос к базе данных для выборки уникальных годов
                string query = "SELECT DISTINCT YEAR(dates) AS Year FROM technique_morning";
                SqlCommand command = db.ExecuteQuery(query);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Заполняем выпадающий список годов
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
                // Заполняем выпадающий список месяцев
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

        private void SaveDataToDataBase()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    int id = Convert.ToInt32(row.Cells["id"].Value);
                    DateTime date = Convert.ToDateTime(row.Cells["dates"].Value);
                    int loptops1 = Convert.ToInt32(row.Cells["loptops_1"].Value);
                    int loptops2 = Convert.ToInt32(row.Cells["loptops_2"].Value);
                    int projectors = Convert.ToInt32(row.Cells["projectors"].Value);
                    int webcamLogitech = Convert.ToInt32(row.Cells["webcam_logitech"].Value);
                    int webcamNlo = Convert.ToInt32(row.Cells["webcam_nlo"].Value);
                    int webcamTower = Convert.ToInt32(row.Cells["webcam_tower"].Value);

                    //SQL - запрос
                    string query = "";
                    if (id == 0)
                    {
                        query = $"INSERT INTO technique_morning (dates, loptops_1, loptops_2, projectors, webcam_logitech, webcam_nlo, webcam_tower)" +
                            $"VALUES ('{date.ToString("yyyy-MM-dd")}', {loptops1}, {loptops2}, {projectors}, {webcamLogitech}, {webcamNlo}, {webcamTower})";
                    }
                    else
                    {
                        query = $"UPDATE technique_morning SET dates = '{date.ToString("yyyy-MM-dd")}', loptops_1 = {loptops1}, loptops_2 = {loptops2}, " +
                        $"projectors = {projectors}, webcam_logitech = {webcamLogitech}, webcam_nlo = {webcamNlo}, webcam_tower = {webcamTower} " +
                        $"WHERE id = {id}";
                    }

                    db.ExecuteNonQuery(query);
                }
            }

            MessageBox.Show("Данные успешно сохранены", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DatesCheck()
        {
            DateTime currentDate = DateTime.Now.Date;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DateTime rowDate;

                if (DateTime.TryParse(row.Cells["dates"].Value.ToString(), out rowDate) && rowDate.Date != currentDate)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.ReadOnly = true;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int columnIndex = e.ColumnIndex;

            if (dataGridView1.Columns[columnIndex].Name == "dates")
            {
                e.Cancel = true;
                MessageBox.Show("Редактирование даты запрещено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime currentDate = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["dates"].Value.ToString());

                DateTime now = DateTime.Now.Date;

                if (columnIndex != dataGridView1.Columns["dates"].Index && currentDate != now)
                {
                    e.Cancel = true;
                    MessageBox.Show("Вы можете редактировать только столбец с текущей датой.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
