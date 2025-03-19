using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using WarehouseMob.DataBase;

namespace WarehouseMob
{
    public class AuthService
    {
        private readonly DatabaseContext _database;

        public AuthService(DatabaseContext database)
        {
            _database = database;
        }

        // Метод для генерации случайного кода подтверждения
        private string GenerateConfirmationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // 6-значный код
        }

        // Метод для отправки email с кодом подтверждения
        private Task SendConfirmationEmailAsync(string email, string confirmationCode)
        {
            var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com", // SMTP-сервер Gmail
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("valeria1739poglazova@gmail.com", "wqlr uqgk fqag melt")

                    };
                    // Создание объекта письма
                    MailMessage mail = new MailMessage();
                    // Установка адреса отправителя
                    mail.From = new MailAddress("vip66vish@gmail.com", "WarehouseMob");

                    // Получатель письма
                    mail.To.Add(email);

                    // Тема письма
                    mail.Subject = "Код подтверждения";

                    // Текст письма
                    mail.Body = $"Ваш код подтверждения: {confirmationCode}";

                    // Отправка письма
                    smtp.Send(mail);
            return Task.CompletedTask;
        }

        // Первый этап аутентификации: проверка почты и пароля
        public async Task<Пользователи> AuthenticateAsync(string email, string password)
        {
            // Получаем пользователя по email
            var пользователь = await _database.GetПользовательПоПочтеAsync(email);
            if (пользователь == null)
            {
                throw new Exception("Пользователь с такой почтой не найден.");
            }

            // Проверяем пароль
            if (!PasswordHelper.VerifyPassword(password, пользователь.ХэшПароля))
            {
                throw new Exception("Неверный пароль.");
            }

            // Генерируем код подтверждения
            var confirmationCode = GenerateConfirmationCode();

            // Отправляем код подтверждения на email
            await SendConfirmationEmailAsync(email, confirmationCode);

            // Сохраняем код подтверждения в объекте пользователя (или в базе данных)
            пользователь.Токен = confirmationCode;

            return пользователь;
        }

        // Второй этап аутентификации: проверка токена
        public bool VerifyToken(Пользователи пользователь, string токен)
        {
            return пользователь.Токен.Equals(токен, StringComparison.OrdinalIgnoreCase);
        }
    }
}