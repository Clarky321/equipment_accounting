﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace equipment_accounting
{
    public partial class frmLog_in : Form
    {
        private DataBase db;
        bool isAdmin = false;
        public event EventHandler<bool> SuccessfulLogin;

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public frmLog_in(bool isAdmin)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            db = new DataBase("MyConnectionStringSql");

            this.isAdmin = isAdmin;
            btnText_password.UseSystemPasswordChar = true;
        }

        private void frmLog_in_Load(object sender, EventArgs e)
        {
            SetMaxLengths();
            LoadUserLogins();
        }

        private void AuthAccouts()
        {
            // Получаем логин и пароль пользователя
            string loginUser = btnCombo_login.Text;
            string passwordUser = btnText_password.Text;

            // Создаем SQL запрос для проверки авторизации пользователя
            string query = $"SELECT isAdmin FROM register WHERE login_user = '{loginUser}' AND password_user = '{passwordUser}'";

            try
            {
                db.OpenConnection();

                // Выполняем запрос к базе данных
                var command = db.ExecuteQuery(query);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        isAdmin = reader.GetBoolean(0);
                    }
                    else
                    {
                        // Если записи не найдены, выводим сообщение об ошибке
                        MessageBox.Show("Неправильный логин или пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Завершаем метод, чтобы предотвратить дальнейшие действия
                    }
                }

                // Если найдены записи, то авторизация успешна
                if (isAdmin)
                {
                    // Администратор вошел в систему
                    MessageBox.Show("Вы вошли в систему как администратор", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Пользователь вошел в систему
                    MessageBox.Show("Вы вошли в систему", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Вызываем событие успешной авторизации
                SuccessfulLogin?.Invoke(this, isAdmin);
            }
            catch (Exception ex)
            {
                // В случае ошибки выводим сообщение с ошибкой
                MessageBox.Show("Ошибка при выполнении запроса: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Закрываем соединение с базой данных
                db.CloseConnection();
            }

            Close();
        }

        private void btnEnter_Click(object sender, EventArgs e) { AuthAccouts(); }

        // Метод для установки максимальной длины текстовых полей
        private void SetMaxLengths() { btnCombo_login.MaxLength = 50; btnText_password.MaxLength = 50; }

        // Метод для загрузки логинов пользователей в выпадающий список
        private void LoadUserLogins()
        {
            try
            {
                List<string> logins = db.GetUniqueUserLogins();

                btnCombo_login.Items.AddRange(logins.ToArray());
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Ошибка при загрузке логинов: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool IsAdminLogins() { return isAdmin; }

        private void check_password_CheckedChanged(object sender, EventArgs e) { btnText_password.UseSystemPasswordChar = !check_password.Checked; }

        private void btn_close_Click(object sender, EventArgs e) { Application.Exit(); }

        private void btn_subtrack_Click(object sender, EventArgs e) { WindowState = FormWindowState.Minimized; }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = Location;
            }

            //    Task.Run(
            //         () =>
            //    {
            //        FuckMyLive();
            //    });
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