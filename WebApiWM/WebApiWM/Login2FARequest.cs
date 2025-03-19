using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWM
{
    public class Login2FARequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}