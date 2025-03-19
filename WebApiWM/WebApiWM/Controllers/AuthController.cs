﻿
using System.Web.Http;
using static WebApiWM.IAuthService;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using WebApiWM;
using Microsoft.AspNetCore.Mvc;

namespace WebApiWM.Controllers
{
    [System.Web.Http.RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [System.Web.Http.Route("login")]
        public IHttpActionResult Login([FromBody] LoginRequest request)
        {
            var user = _authService.Authenticate(request.Email, request.Password);
            if (user == null)
                return Unauthorized();

            return Ok(user);
        }

        [HttpPost]
        [System.Web.Http.Route("login-2fa")]
        public IHttpActionResult LoginWith2FA([FromBody] Login2FARequest request)
        {
            var user = _authService.AuthenticateWith2FA(request.Email, request.Token);
            if (user == null)
                return Unauthorized();

            return Ok(user);
        }
    }
}