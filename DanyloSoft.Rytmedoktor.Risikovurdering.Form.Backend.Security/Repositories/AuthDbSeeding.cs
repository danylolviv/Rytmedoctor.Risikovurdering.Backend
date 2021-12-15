using System.Text;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public class AuthDbSeeding : IAuthDbSeeder
  {
    private  AuthDbContext _ctx;
    private  ISecurityService _securityService;

    public AuthDbSeeding(AuthDbContext ctx, ISecurityService securityService)
    {
      _ctx = ctx;
      _securityService = securityService;
    }

    public void SeedDevelopment()
    {
      _ctx.Database.EnsureDeleted();
      _ctx.Database.EnsureCreated();

      var salt = "shim123!#";
      
      _ctx.LoginUsers.Add(new LoginUserEntity()
      {
        Id = 1, 
        HashedPassword = _securityService.HashedPassword(Encoding.ASCII.GetBytes(salt), "petro"),
        Salt = salt,
        Username = "petro"
      } );
      _ctx.LoginUsers.Add(new LoginUserEntity()
        {Id = 2, 
          HashedPassword = _securityService.HashedPassword(Encoding.ASCII.GetBytes(salt), "password"), 
          Salt = salt, 
          Username = "admin"});
      _ctx.LoginUsers.Add(new LoginUserEntity()
        {Id = 3, 
          HashedPassword = _securityService.HashedPassword(Encoding.ASCII.GetBytes(salt), "password"), 
          Salt = salt, 
          Username = "user"});

      _ctx.SaveChanges();
    }

    public void SeedProduction()
    {
      throw new System.NotImplementedException();
    }
  }
}