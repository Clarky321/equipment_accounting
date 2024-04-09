using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

            //dataGridView1.AllowUserToAddRows = false;
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

        private void SaveChanges()
        {
            try
            {
                db.OpenConnection();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && row.Cells[0].Value != null)
                    {
                        int id = Convert.ToInt32(row.Cells["id_user"].Value);
                        string login = row.Cells["login_user"].Value.ToString();
                        string password = row.Cells["password_user"].Value.ToString();
                        bool isAdmin = Convert.ToBoolean(row.Cells["isAdmin"].Value);

                        if (id == 0)
                        {
                            string query = $"INSERT INTO register (login_user, password_user, isAdmin) VALUES ('{login}', '{password}', '{isAdmin}')";

                            db.ExecuteQuery(query);
                        }
                        else
                        {
                            // Выполните запрос на обновление записи
                            string query = $"UPDATE register SET login_user = '{login}', password_user = '{password}', isAdmin = '{isAdmin}'" +
                                           $"WHERE id_user = {id}";

                            db.ExecuteQuery(query);
                        }
                    }
                }

                AddLog("Log: Изменения сохранены успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayData();
        }
    }
}
