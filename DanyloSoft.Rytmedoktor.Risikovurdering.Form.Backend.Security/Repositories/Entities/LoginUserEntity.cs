using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public class LoginUserEntity
  {
    public int Id { get; set; }
    public string Username  { get; set; }
    public string HashedPassword { get; set; }
    public string Salt { get; set; }
  }
}