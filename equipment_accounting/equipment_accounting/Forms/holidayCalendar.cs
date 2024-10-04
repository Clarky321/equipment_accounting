using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace equipment_accounting.Forms
{
    public partial class holidayCalendar : Form
    {
        private DataBase db;
        int month, year;

        public static int static_month, static_year;

        public holidayCalendar()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            db = new DataBase("MyConnectionStringSql");
        }

        private void holidayCalendar_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;
            DisplayCalendar(month, year);

            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //Resize += new System.EventHandler(holidayCalendar);
        }

        private void DisplayCalendar(int month, int year)
        {
            daycontainer.Controls.Clear();

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            static_month = month;
            static_year = year;

            DateTime startOfMonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);

            int dayOfWeek = ((int)startOfMonth.DayOfWeek + 6) % 7;

            for (int i = 0; i < dayOfWeek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);

                string date = $"{year}-{month:D2}-{i:D2}";
                var eventDetailsList = GetEventDetails(date);

                if (eventDetailsList.Count > 0)
                {
                    ucdays.SetEventDetails(eventDetailsList); // Передаём список сотрудников для отображения
                }

                daycontainer.Controls.Add(ucdays);
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

        private void btnPrev_Click(object sender, EventArgs e)
        {
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            DisplayCalendar(month, year);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            DisplayCalendar(month, year);
        }
    }
}
