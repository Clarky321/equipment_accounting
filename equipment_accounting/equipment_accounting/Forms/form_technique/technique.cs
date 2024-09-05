using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySqlConnector;

namespace equipment_accounting.Forms
{
    public partial class technique : Form
    {
        private DataBase db;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public technique()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");

            textBox_dates.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox_dates.ReadOnly = true;
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_loptops_1.Text) ||
                string.IsNullOrWhiteSpace(textBox_dates.Text) ||
                comboBox_names.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string table = radioButton_morning.Checked ? "technique_morning" : "technique_night";
            string query = $@"UPDATE {table} 
                              SET loptops_1 = @Laptops1, loptops_2 = @Laptops2, projectors = @Projectors, 
                                  webcam_logitech = @WebcamLogitech, webcam_nlo = @WebcamNlo, webcam_tower = @WebcamTower, 
                                  names = @Names, message = @Message
                              WHERE dates = @Date";

            try
            {
                db.OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, db.Connection))
                {
                    cmd.Parameters.AddWithValue("@Date", DateTime.Parse(textBox_dates.Text));
                    cmd.Parameters.AddWithValue("@Laptops1", Convert.ToInt32(textBox_loptops_1.Text));
                    cmd.Parameters.AddWithValue("@Laptops2", Convert.ToInt32(textBox_loptops_2.Text));
                    cmd.Parameters.AddWithValue("@Projectors", Convert.ToInt32(textBox_projectors.Text));
                    cmd.Parameters.AddWithValue("@WebcamLogitech", Convert.ToInt32(textBox_webcam_logitech.Text));
                    cmd.Parameters.AddWithValue("@WebcamNlo", Convert.ToInt32(textBox_webcam_nlo.Text));
                    cmd.Parameters.AddWithValue("@WebcamTower", Convert.ToInt32(textBox_webcam_tower.Text));
                    cmd.Parameters.AddWithValue("@Names", comboBox_names.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Message", textBox_message.Text);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearField();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить данные. Возможно, данные с такой датой не найдены.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void ClearField()
        {
            textBox_dates.Clear();
            textBox_loptops_1.Clear();
            textBox_loptops_2.Clear();
            textBox_projectors.Clear();
            textBox_webcam_logitech.Clear();
            textBox_webcam_nlo.Clear();
            textBox_webcam_tower.Clear();
            textBox_message.Clear();
        }

        private void btn_close_Click(object sender, EventArgs e) { Hide(); }

        private void btn_subtrack_Click(object sender, EventArgs e) { WindowState = FormWindowState.Minimized; }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && e.Button == MouseButtons.Left)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}