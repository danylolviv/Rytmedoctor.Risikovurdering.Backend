using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI.Dto;
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
            try
            {
                var token =
                    _service.GenerateJwtToken(dto.Username, dto.Password);
                return Ok(new TokenDto
                {
                    Jwt = token.Jwt,
                    Message = token.Message
                });
            }
            catch (AuthenticationException authException)
            {
                return Unauthorized(authException.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Please contact admin, aka horribly wrong, deploying");
            }
        }

        [HttpPost(nameof(CreateUser))]
        public ActionResult<AuthUserDto> CreateUser([FromBody] CreateAuthUserDto createAuthUserDto)
        {
            try
            {
                var authUser =
                    _service.GenerateNewAuthUser(createAuthUserDto.Username);
                return new AuthUserDto
                {
                    Id = authUser.Id, 
                    Username = authUser.Username
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "contact administration");
            }
        }

    }
}