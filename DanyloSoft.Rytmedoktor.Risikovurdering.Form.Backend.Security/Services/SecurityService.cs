using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security.Services
{
  public class SecurityService : ISecurityService
  {
    public SecurityService(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; set; }

    public JwtToken generateJwtToken(string username, string password)
    {
      var securityKey =
        new SymmetricSecurityKey(
          Encoding.UTF8.GetBytes(Configuration["jwtConfig:secret"]));
      var credentials =
        new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
      var token = new JwtSecurityToken(Configuration["jwtConfig:issuer"],
        Configuration["jwtConfig:audience"],
        null,
        expires: DateTime.Now.AddMinutes(10),
        signingCredentials: credentials);
      return new JwtToken()
      {
        Jwt = new JwtSecurityTokenHandler().WriteToken(token),
        Message = "Ok"
      }; 
    }
  }
}