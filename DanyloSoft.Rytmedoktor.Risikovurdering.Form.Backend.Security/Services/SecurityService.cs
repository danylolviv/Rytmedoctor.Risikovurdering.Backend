using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

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

    public JwtToken GenerateJwtToken(string username, string password)
    {
      var user = _authServ.GetUser(username);
      if (Authenticate(user, password))
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
      throw new AuthenticationException("username or password is incorrect");
    }

    private bool Authenticate(AuthUser user, string password)
    {
      if (user == null || user.HashedPassword.Length <= 0 || user.Salt.Length <= 0) return false;
      
        var hashedPassword = HashedPassword(user.Salt, password);

        return hashedPassword.Equals(user.HashedPassword);
    }

    public string HashedPassword(byte[] userSalt, string password)
    {
      return Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: password,
        salt: userSalt,
        prf: KeyDerivationPrf.HMACSHA256,
        iterationCount: 100000,
        numBytesRequested: 256 / 8));
    }
  }
}