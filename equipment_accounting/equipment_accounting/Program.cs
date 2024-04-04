using System;
using System.Threading;
using System.Windows.Forms;

namespace equipment_accounting
{
    internal static class Program
    {
        public class MultiFormContext : ApplicationContext
        {
            private int openForms;

            private readonly Form menuForm;
            private readonly Form loginForm;

            public MultiFormContext(Form menuForm, Form loginForm)
            {
                this.menuForm = menuForm;
                this.loginForm = loginForm;

                menuForm.FormClosed += (s, args) =>
                {
                    if (Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };

                loginForm.FormClosed += (s, args) =>
                {
                    if (Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };

                ShowForm(menuForm);
                ShowForm(loginForm);
                Interlocked.Increment(ref openForms);
                Interlocked.Increment(ref openForms);
            }

            public void ShowForm(Form form)
            {
                form.FormClosed += (s, args) =>
                {
                    if (Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };

                Interlocked.Increment(ref openForms);
                form.Show();
            }

            // Метод для разрешения доступа к форме меню после успешной аутентификации
            public void AllowAccessToMenu()
            {
                menuForm.Enabled = true;
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var menuForm = new frmMenu();
            var loginForm = new frmLog_in();

            var context = new MultiFormContext(menuForm, loginForm);

            loginForm.SuccessfulLogin += (s, isAdmin) =>
            {
                // Передаем isAdmin в конструктор формы меню
                var menuForm = new frmMenu(isAdmin);

                // Убираем создание лишней формы авторизации
                //var context = new MultiFormContext(menuForm, loginForm);

                // Разрешаем доступ к форме меню после успешной аутентификации
                context.AllowAccessToMenu();

                // Прячем форму авторизации после успешной аутентификации
                loginForm.Hide();

                // Показываем только форму меню
                context.ShowForm(menuForm);
            };

            Application.Run(context);
        }
    }
}