namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public class AuthDbSeeding
  {
    private readonly AuthDbContext _ctx;

    public AuthDbSeeding(AuthDbContext ctx)
    {
      _ctx = ctx;
      SeedDevelopment();
    }

    public void SeedDevelopment()
    {
      _ctx.Database.EnsureDeleted();
      _ctx.Database.EnsureCreated();
      
      _ctx.LoginUsers.Add(new LoginUserEntity()
        {Id = 1, HashedPassword = "petro", Username = "petro"});
      _ctx.LoginUsers.Add(new LoginUserEntity()
        {Id = 2, HashedPassword = "password", Username = "admin"});
      _ctx.LoginUsers.Add(new LoginUserEntity()
        {Id = 3, HashedPassword = "password", Username = "user"});

      _ctx.SaveChanges();
    }
  }
}