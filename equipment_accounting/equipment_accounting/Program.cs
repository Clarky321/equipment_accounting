using System;
using System.Threading;
using System.Windows.Forms;

namespace equipment_accounting
{
    internal static class Program
    {
        // Класс для управления контекстом приложения с несколькими формами
        public class MultiFormContext : ApplicationContext
        {
            // Счетчик открытых форм
            private int openForms;
            // Форма меню и форма входа
            private readonly frmMenu menuForm;
            private readonly frmLog_in loginForm;
            // Конструктор класса MultiFormContext
            public MultiFormContext(frmMenu menuForm, frmLog_in loginForm)
            {
                this.menuForm = menuForm;
                this.loginForm = loginForm;
                // Подписываемся на событие успешной аутентификации
                loginForm.SuccessfulLogin += OnSuccessfulLogin;
                // Показываем форму входа при запуске приложения
                ShowForm(loginForm);
                // Увеличиваем счетчик открытых форм
                Interlocked.Increment(ref openForms);
            }
            // Метод для показа формы
            public void ShowForm(Form form)
            {
                form.FormClosed += (s, args) =>
                {
                    // Уменьшаем счетчик открытых форм и завершаем приложение, если все формы закрыты
                    if (Interlocked.Decrement(ref openForms) == 0)
                        ExitThread();
                };
                // Увеличиваем счетчик открытых форм и показываем форму
                Interlocked.Increment(ref openForms);
                form.Show();
            }

            // Метод для разрешения доступа к форме меню после успешной аутентификации
            private void OnSuccessfulLogin(object sender, bool isAdmin)
            {
                loginForm.Hide();

                // Устанавливаем доступ администратора для формы меню и показываем её
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
            // Создаем контекст приложения с несколькими формами
            var context = new MultiFormContext(menuForm, loginForm);
            // Запускаем приложение
            Application.Run(context);
        }
    }
}