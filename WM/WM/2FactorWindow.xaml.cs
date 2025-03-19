using System;
using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Security.Cryptography.X509Certificates;
namespace WM
{
    /// <summary>
    /// Логика взаимодействия для _2FactorWindow.xaml
    /// </summary>
    public partial class _2FactorWindow : Window
    {
       
        private readonly Пользователи _user;
        private readonly Window _mainWindow;

        private string _confirmationCode;

        public _2FactorWindow(Пользователи user, Window mainWindow)
        {
            InitializeComponent();
            _user = user;
            _mainWindow = mainWindow;

            // Генерация и отправка кода подтверждения
            _confirmationCode = GenerateConfirmationCode();
            SendConfirmationEmail(_user.Email, _confirmationCode);

            MessageBox.Show("Код подтверждения отправлен на ваш email.");
        }

        private string GenerateConfirmationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString(); // Генерация 6-значного кода
        }

        private void SendConfirmationEmail(string email, string confirmationCode)
        {
            try
            {
                // Настройка SMTP-клиента
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("valeria1739poglazova@gmail.com", "wqlr uqgk fqag melt");
                    smtpClient.EnableSsl = true;

                    // Создание объекта письма
                    MailMessage mail = new MailMessage();
                    // Установка адреса отправителя
                    mail.From = new MailAddress("vip66vish@gmail.com");

                    // Получатель письма
                    mail.To.Add(email);

                    // Тема письма
                    mail.Subject = "Код подтверждения";

                    // Текст письма
                    mail.Body = $"Ваш код подтверждения: {confirmationCode}";

                    // Отправка письма
                    smtpClient.Send(mail);
                }
            }
            catch (SmtpException ex)
            {
                MessageBox.Show($"Ошибка при отправке email: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }


        private void Author_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SecretWord.Text))
            {
                MessageBox.Show("Введите код подтверждения.");
                return;
            }

            if (SecretWord.Text == _confirmationCode) // Проверка кода подтверждения
            {
                MessageBox.Show("Успешная авторизация!");
                OpenRoleSpecificWindow(_user.Роль);
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный код подтверждения.");
            }
        }

        private void OpenRoleSpecificWindow(string роль)
        {
            try
            {
                switch (роль)
                {
                    case "Администратор":
                        new Admin(_user.IDПользователя).Show();
                        break;
                    case "Кладовщик":
                        new Storekeeper(_user.IDПользователя).Show();
                        break;
                    case "Менеджер по продажам":
                       new Sales_Manager(_user.IDПользователя).Show();
                        break;
                    case "Бухгалтер":
                        new Accountant(_user.IDПользователя).Show();
                        break;
                    default:
                        MessageBox.Show("Роль не определена.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии окна: {ex.Message}");
            }
        }
    }
}