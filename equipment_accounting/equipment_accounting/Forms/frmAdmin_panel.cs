using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace equipment_accounting
{
    public partial class frmAdmin_panel : Form
    {
        private DataBase db;

        public frmAdmin_panel()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");

            DisplayData();
        }

        private void frmAdmin_panel_Load(object sender, EventArgs e)
        {
            // вечер
            selectedYear_1();
            selectedMonth_1();

            // утро
            selectedYear_2();
            selectedMonth_2();
        }

        private void HeaderText()
        {
            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns["login_user"].HeaderText = "Логин";
            dataGridView1.Columns["password_user"].HeaderText = "Пароль";
            dataGridView1.Columns["isAdmin"].HeaderText = "Администратор";
        }

        private void DataGirdSize()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // Вывод в Log Console
        private void AddLog(string message)
        {
            textBoxConsole.AppendText(message + Environment.NewLine);
        }

        private void BaseConnectInfo()
        {
            try
            {
                db.OpenConnection();

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
                db.CloseConnection();
            }
        }

        private void GetDatabaseInfo()
        {
            try
            {
                string query = "SELECT DATABASE() AS 'DatabaseName', USER() 'CurrentUser', VERSION() AS 'DBVersion'";

                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    string databaseName = reader["DatabaseName"].ToString();
                    string currentUser = reader["CurrentUser"].ToString();
                    string dbVersion = reader["DBVersion"].ToString();

                    AddLog($"Database Name: {databaseName}");
                    AddLog($"Current User: {currentUser}");
                    AddLog($"Database Version: {dbVersion}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка выполнения SQL запроса: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            BaseConnectInfo();
        }

        private void btnBaseInfo_Click(object sender, EventArgs e)
        {
            GetDatabaseInfo();
        }

        private void DisplayData()
        {
            try
            {
                db.OpenConnection();

                string query = "SELECT * FROM register";

                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;

                HeaderText();
                DataGirdSize();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                db.CloseConnection();
            }
        }

        private void sqlQuery()
        {
            try
            {
                string query = textBoxConsole.Text;

                if (string.IsNullOrEmpty(query))
                {
                    MessageBox.Show("Введите SQL запрос", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    return;
                }

                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Очистите textBoxConsole перед добавлением новой информации
                textBoxConsole.Clear();

                // Переберите строки результата и добавьте их в textBoxConsole
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (DataColumn col in dataTable.Columns)
                    {
                        textBoxConsole.AppendText(row[col] + " ");
                    }
                    textBoxConsole.AppendText(Environment.NewLine);
                }

                AddLog("Log: Запрос успешно выполнен" + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка выполнения SQL запроса: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            sqlQuery();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void selectedYear_1()
        {
            try
            {
                // Запрос к базе данных для выборки уникальных годов
                string query = "SELECT DISTINCT YEAR(dates) AS Year FROM technique_night";
                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Заполняем выпадающий список годов
                comboBox_year1.DisplayMember = "Year";
                comboBox_year1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке годов из базы данных: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectedMonth_1()
        {
            try
            {
                // Заполняем выпадающий список месяцев
                comboBox_month1.Items.AddRange(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке месяцев: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectedYear_2()
        {
            try
            {
                // Запрос к базе данных для выборки уникальных годов
                string query = "SELECT DISTINCT YEAR(dates) AS Year FROM technique_morning";
                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Заполняем выпадающий список годов
                comboBox_year2.DisplayMember = "Year";
                comboBox_year2.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке годов из базы данных: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectedMonth_2()
        {
            try
            {
                // Заполняем выпадающий список месяцев
                comboBox_month2.Items.AddRange(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке месяцев: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportToExcel(DataTable dataTable, int selectedYear, int selectedMonth)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true; // Открывать Excel визуально

                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                // Добавляем заголовки столбцов
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dataTable.Columns[i].ColumnName;
                }

                // Заполняем данные
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataTable.Rows[i][j];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при экспорте данных в Excel: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportNight_Click(object sender, EventArgs e)
        {
            try
            {
                db.OpenConnection();

                // Получаем выбранные год и месяц из ComboBox'ов
                int selectedYear = int.Parse(comboBox_year1.Text);
                int selectedMonth = comboBox_month1.SelectedIndex + 1; // Получаем номер месяца

                // Формируем SQL-запрос с учетом выбранного года и месяца
                string query = "SELECT * FROM technique_night";

                // Добавляем условие WHERE только если выбран год или месяц
                if (selectedYear > 0 || selectedMonth > 0)
                {
                    query += " WHERE ";

                    if (selectedYear > 0)
                    {
                        query += $"YEAR(dates) = {selectedYear}";

                        if (selectedMonth > 0)
                        {
                            query += " AND ";
                        }
                    }

                    if (selectedMonth > 0)
                    {
                        query += $"MONTH(dates) = {selectedMonth}";
                    }
                }

                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ImportToExcel(dataTable, selectedYear, selectedMonth);

                AddLog("Log: Данные успешно экспортированы в Excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при экспорте данных в Excel: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void btnImportDay_Click(object sender, EventArgs e)
        {
            try
            {
                db.OpenConnection();

                // Получаем выбранные год и месяц из ComboBox'ов
                int selectedYear = int.Parse(comboBox_year2.Text);
                int selectedMonth = comboBox_month2.SelectedIndex + 1; // Получаем номер месяца

                // Формируем SQL-запрос с учетом выбранного года и месяца
                string query = "SELECT * FROM technique_morning";

                // Добавляем условие WHERE только если выбран год или месяц
                if (selectedYear > 0 || selectedMonth > 0)
                {
                    query += " WHERE ";

                    if (selectedYear > 0)
                    {
                        query += $"YEAR(dates) = {selectedYear}";

                        if (selectedMonth > 0)
                        {
                            query += " AND ";
                        }
                    }

                    if (selectedMonth > 0)
                    {
                        query += $"MONTH(dates) = {selectedMonth}";
                    }
                }

                MySqlCommand command = db.ExecuteQuery(query);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                ImportToExcel(dataTable, selectedYear, selectedMonth);

                AddLog("Log: Данные успешно экспортированы в Excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при экспорте данных в Excel: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSign_up sign_Up = new frmSign_up();
            sign_Up.ShowDialog();
        }

        private void DeleteRecord(int idToDelete)
        {
            try
            {
                db.OpenConnection();

                string query = $"DELETE FROM register WHERE id_user = {idToDelete}";
                db.ExecuteNonQuery(query);

                MessageBox.Show("Запись успешно удалена", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayData(); // Обновление отображения данных после удаления записи
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении записи: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idToDelete = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id_user"].Value);
                    DeleteRecord(idToDelete);
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
