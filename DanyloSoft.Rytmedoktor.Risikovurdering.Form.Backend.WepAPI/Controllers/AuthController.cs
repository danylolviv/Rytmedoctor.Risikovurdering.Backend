using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ISecurityService _service;
        
        public AuthController(ISecurityService service)
        {
            _service = service;
        }
         
        [AllowAnonymous ]
        [HttpPost(nameof(Login))]
        public ActionResult<TokenDto> Login(LoginDto dto)
        {
            var token = _service.generateJwtToken(dto.Username, dto.Password);
            return new TokenDto()
            {
                Jwt = token.Jwt,
                Message = token.Message
            };
        }

    }

    public class TokenDto
    {
        public string Jwt { get; set; }
        public string Message { get; set; }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}