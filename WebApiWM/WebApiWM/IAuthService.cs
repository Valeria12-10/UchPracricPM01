using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiWM.Entities;
using WebApiWM.Models;

namespace WebApiWM
{
    public interface IAuthService
    {
        R_User Authenticate(string email, string password);
        R_User AuthenticateWith2FA(string email, string token);
    }


    public class AuthService : IAuthService
    {
        private readonly СкладыEntities _context;

        public AuthService(СкладыEntities context)
        {
            _context = context;
        }

        public R_User Authenticate(string email, string password)
        {
            // Ищем пользователя в базе данных
            var пользователь = _context.Пользователи
                .SingleOrDefault(u => u.Email == email && u.ХэшПароля == password);

            if (пользователь == null)
                return null;

            // Возвращаем объект R_User
            return new R_User(пользователь);
        }

        public R_User AuthenticateWith2FA(string email, string token)
        {
            // Ищем пользователя в базе данных
            var пользователь = _context.Пользователи
                .SingleOrDefault(u => u.Email == email);

            // Проверяем токен (здесь должна быть логика проверки 2FA)
            if (пользователь == null || token != "valid_2fa_token")
                return null;

            // Возвращаем объект R_User
            return new R_User(пользователь);
        }
    }
}