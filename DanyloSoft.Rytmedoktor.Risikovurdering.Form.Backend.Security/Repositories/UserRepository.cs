using System;
using System.IO;
using System.Linq;
using System.Text;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Transformers;
using Microsoft.EntityFrameworkCore;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public class UserRepository : IUserRepository
  {
    private AuthDbContext _ctx;

    public UserRepository(AuthDbContext ctx)
    {
      {
        if (ctx == null)
        {
          throw new InvalidDataException("DbContext cannot be null");
        }
        _ctx = ctx;
      }
    }
    
    public AuthUser FindUser(string username)
    {
      var userEntity = _ctx.LoginUsers.FirstOrDefault(user =>
        username.Equals(user.Username));
      if (userEntity == null) return null;
      return new AuthUser()
      {
        Id = userEntity.Id,
        Username = userEntity.Username,
        HashedPassword = userEntity.HashedPassword,
        Salt = Convert.FromBase64String(userEntity.Salt)
      };
    }

    public AuthUser SaveUser(AuthUser authUser)
    {
      var entity = _ctx.Add(new LoginUserEntity()
      {
        HashedPassword = authUser.HashedPassword,
        Salt = Convert.ToBase64String(authUser.Salt),
        Username = authUser.Username
      }).Entity;
      _ctx.SaveChanges();
      return new AuthUser {Id = entity.Id, Username = entity.Username};
    }
  }
}