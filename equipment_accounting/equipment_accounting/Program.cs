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

            private readonly frmMenu menuForm;
            private readonly frmLog_in loginForm;

            public MultiFormContext(frmMenu menuForm, frmLog_in loginForm)
            {
                this.menuForm = menuForm;
                this.loginForm = loginForm;

                loginForm.SuccessfulLogin += OnSuccessfulLogin;

                ShowForm(loginForm);

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
            private void OnSuccessfulLogin(object sender, bool isAdmin)
            {
                loginForm.Hide();

                menuForm.SetAdminAccess(isAdmin);

                ShowForm(menuForm);
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loginForm = new frmLog_in(false); // Передаем false, так как не указываем явно, администратор это или нет
            var menuForm = new frmMenu(false); // Передаем false, так как на старте неизвестно, администратор это или нет

            var context = new MultiFormContext(menuForm, loginForm);

            Application.Run(context);
        }
    }
}