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
      _securityService.GenerateNewAuthUser("petro");
    }

    public void SeedProduction()
    {
      _ctx.Database.EnsureCreated();
      _securityService.GenerateNewAuthUser("petro");
    }
  }
}