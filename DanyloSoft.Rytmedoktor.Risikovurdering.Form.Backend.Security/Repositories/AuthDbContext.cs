using Microsoft.EntityFrameworkCore;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public class AuthDbContext : DbContext
  {
    public AuthDbContext(DbContextOptions<AuthDbContext> options) :base(options)
    {
      
    }

    public DbSet<LoginUserEntity> LoginUsers { get; set; }
    
  }
}