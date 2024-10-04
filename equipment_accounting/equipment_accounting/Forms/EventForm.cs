using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySqlConnector;

namespace equipment_accounting.Forms
{
    public partial class EventForm : Form
    {
        private DataBase db;
        private string selectedDate;

        // Список для хранения информации о сотрудниках, добавленных за одну дату
        private List<(string name, string shift, string message, string color)> employeesForDate;

        public EventForm(string selectedDate)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");
            this.selectedDate = selectedDate;

            employeesForDate = new List<(string name, string shift, string message, string color)>();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            textBox_dates.Text = selectedDate;

            comboBox_station.Items.AddRange(new string[] { "Утро", "Вечер", "Весь день" });
            comboBox_names.Items.AddRange(new string[] { "Рябов С.Д", "Вареничев Н.В", "Копченов М.В", "Рясов И.Д", "Москалев Р.В", "Кулагин В.В", "Цывинский А.Ю", "Виктор" });
            comboBox_color.Items.AddRange(new string[] { "Красный", "Чёрный", "Синий" });

            // Загружаем сотрудников для выбранной даты, если они есть
            var employees = GetEventDetails(selectedDate);

            foreach (var employee in employees)
            {
                employeesForDate.Add((employee.name, employee.shift, "", employee.color));
                listBox_employees.Items.Add($"{employee.name} - {employee.shift} - {employee.color}");
            }
        }

        private List<(string name, string shift, string color)> GetEventDetails(string date)
        {
            string query = $"SELECT EmployeeName, ShiftType, Color FROM CalendarEvents WHERE EventDate = '{date}'";
            MySqlCommand cmd = db.ExecuteQuery(query);
            MySqlDataReader reader = cmd.ExecuteReader();

            List<(string name, string shift, string color)> eventDetails = new List<(string name, string shift, string color)>();

            while (reader.Read())
            {
                string name = reader["EmployeeName"].ToString();
                string shift = reader["ShiftType"].ToString();
                string color = reader["Color"].ToString();

                eventDetails.Add((name, shift, color));
            }
            reader.Close();
            return eventDetails;
        }

        // Кнопка для добавления сотрудника в список
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            // Проверка на выбор всех необходимых данных
            if (comboBox_names.SelectedItem == null || comboBox_station.SelectedItem == null || comboBox_color.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника, время смены и цвет.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = comboBox_names.SelectedItem.ToString();
            string shift = comboBox_station.SelectedItem.ToString();
            string color = comboBox_color.SelectedItem.ToString(); // Получаем выбранный цвет
            string message = textBox_message.Text;

            // Добавляем сотрудника в список для сохранения
            employeesForDate.Add((name, shift, message, color));

            // Обновляем список сотрудников на форме
            listBox_employees.Items.Add($"{name} - {shift} - {color}");

            // Очищаем выбор для следующих добавлений
            comboBox_names.SelectedIndex = -1;
            comboBox_station.SelectedIndex = -1;
            comboBox_color.SelectedIndex = -1;
            textBox_message.Clear();
        }

        // Кнопка для сохранения всех сотрудников в базе данных
        private void btnSaveDate_Click(object sender, EventArgs e)
        {
            if (employeesForDate.Count == 0)
            {
                MessageBox.Show("Не добавлено ни одного сотрудника!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                db.OpenConnection();

                foreach (var employee in employeesForDate)
                {
                    string checkQuery = $"SELECT COUNT(*) FROM CalendarEvents WHERE EventDate = '{selectedDate}' AND EmployeeName = '{employee.name}'";
                    MySqlCommand checkCmd = db.ExecuteQuery(checkQuery);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // Обновление события, если уже существует для данного сотрудника
                        string updateQuery = $"UPDATE CalendarEvents SET ShiftType = '{employee.shift}', Message = '{employee.message}', Color = '{employee.color}' WHERE EventDate = '{selectedDate}' AND EmployeeName = '{employee.name}'";
                        db.ExecuteNonQuery(updateQuery);
                    }
                    else
                    {
                        // Добавление нового события для сотрудника
                        string insertQuery = $"INSERT INTO CalendarEvents (EventDate, ShiftType, EmployeeName, Message, Color) VALUES ('{selectedDate}', '{employee.shift}', '{employee.name}', '{employee.message}', '{employee.color}')";
                        db.ExecuteNonQuery(insertQuery);
                    }
                }

                MessageBox.Show("Все сотрудники добавлены/обновлены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }

            // Очищаем список сотрудников после сохранения
            employeesForDate.Clear();
            listBox_employees.Items.Clear();
        }

        // Кнопка для удаления сотрудника
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox_employees.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для удаления!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string selectedEmployee = listBox_employees.SelectedItem.ToString();
            string employeeName = selectedEmployee.Split('-')[0].Trim(); // Извлекаем имя сотрудника

            try
            {
                db.OpenConnection();
                string deleteQuery = $"DELETE FROM CalendarEvents WHERE EventDate = '{selectedDate}' AND EmployeeName = '{employeeName}'";
                db.ExecuteNonQuery(deleteQuery);
                MessageBox.Show("Сотрудник удалён!");

                // Удаляем сотрудника из списка на форме
                employeesForDate.RemoveAll(emp => emp.name == employeeName); // Изменено с "e" на "emp"
                listBox_employees.Items.Remove(listBox_employees.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении: " + ex.Message);
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}