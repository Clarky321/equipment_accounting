using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace equipment_accounting.Forms
{
    public partial class UserControlDays : UserControl
    {
        public static string static_day;

        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            ibdays.Text = numday.ToString();
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = ibdays.Text;
            string selectedDate = $"{holidayCalendar.static_year}-{holidayCalendar.static_month:D2}-{static_day:D2}";
            EventForm eventForm = new EventForm(selectedDate);
            eventForm.ShowDialog();
        }

        //public void SetEventDetails(List<(string name, string shift, string color)> eventDetailsList)
        //{
        //    //label1.Text = string.Empty; // Очищаем текст перед добавлением новых данных
        //    //label2.Text = string.Empty;

        //    label1.Controls.Clear();

        //    foreach (var eventDetails in eventDetailsList)
        //    {
        //        string displayText = $"{eventDetails.name} ({eventDetails.shift})\n"; // Форматируем строку с информацией о сотруднике

        //        // Добавляем текст с цветом
        //        // label1.Text += displayText;
        //        // label2.Text += displayText;

        //        // Создаём новый Label для каждого сотрудника
        //        Label employeeLabel = new Label();
        //        employeeLabel.Text = displayText;
        //        employeeLabel.AutoSize = true; // Устанавливаем авторазмер для label

        //        switch (eventDetails.color)
        //        {
        //            case "Чёрный":
        //                employeeLabel.ForeColor = System.Drawing.Color.Black;
        //                break;
        //            case "Красный":
        //                employeeLabel.ForeColor = System.Drawing.Color.Red;
        //                break;
        //            case "Синий":
        //                employeeLabel.ForeColor = System.Drawing.Color.Blue;
        //                break;
        //            default:
        //                employeeLabel.ForeColor = System.Drawing.Color.Black;
        //                break;
        //        }
        //    }

        //    label1.Controls.Add(employeeLabel);

        //    //label1.Visible = true; // Убедимся, что label видим
        //    //label2.Visible = true;
        //}

        public void SetEventDetails(List<(string name, string shift, string color)> eventDetailsList)
        {
            // Очищаем существующие контролы перед добавлением новых
            flowLayoutPanelEmployees.Controls.Clear(); // очищаем flowLayoutPanel перед добавлением новых элементов

            foreach (var eventDetails in eventDetailsList)
            {
                string displayText = $"{eventDetails.name} ({eventDetails.shift})";

                // Создаём новый Label для каждого сотрудника
                Label employeeLabel = new Label();
                employeeLabel.Text = displayText;
                employeeLabel.AutoSize = true; // Устанавливаем авторазмер для label

                // Применяем цвет в зависимости от цвета сотрудника
                switch (eventDetails.color)
                {
                    case "Чёрный":
                        employeeLabel.ForeColor = System.Drawing.Color.Black;
                        break;
                    case "Красный":
                        employeeLabel.ForeColor = System.Drawing.Color.Red;
                        break;
                    case "Синий":
                        employeeLabel.ForeColor = System.Drawing.Color.Blue;
                        break;
                    default:
                        employeeLabel.ForeColor = System.Drawing.Color.Black;
                        break;
                }

                // Добавляем новый label в FlowLayoutPanel
                flowLayoutPanelEmployees.Controls.Add(employeeLabel);
            }
        }
    }
}