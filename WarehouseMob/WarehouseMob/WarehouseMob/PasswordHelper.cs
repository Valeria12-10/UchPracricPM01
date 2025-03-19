using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace WarehouseMob
{
    public static class PasswordHelper
    {
        // Хэширование пароля
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }


        // Проверка пароля
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInput = HashPassword(password);
            return hashedInput.Equals(hashedPassword, StringComparison.OrdinalIgnoreCase);

        }
    }
}
