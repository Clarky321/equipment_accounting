using System;
using System.Diagnostics.Eventing.Reader;
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

            bool isAdminDefault = false;

            var menuForm = new frmMenu(isAdminDefault);
            var loginForm = new frmLog_in(isAdminDefault);

            var context = new MultiFormContext(menuForm, loginForm);

            loginForm.SuccessfulLogin += (s, isAdmin) =>
            {
                loginForm.Hide();

                menuForm.SetAdminAccess(isAdmin);

                context.ShowForm(menuForm);

                context.AllowAccessToMenu();

                menuForm.Show();
            };

            Application.Run(context);
        }
    }
}