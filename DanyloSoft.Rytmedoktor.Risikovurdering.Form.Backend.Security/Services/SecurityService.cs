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
    private readonly IAuthUserService _authServ;


    public SecurityService(IConfiguration configuration, IAuthUserService authServ)
    {
      Configuration = configuration;
      _authServ = authServ;
    }

    public IConfiguration Configuration { get; set; }

    public JwtToken generateJwtToken(string username, string hashedPassword)
    {
      var user = _authServ.Login(username, hashedPassword);
      if (user!= null)
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
      return new JwtToken() {Message = "user was not forund in database"};
    }
  }
}