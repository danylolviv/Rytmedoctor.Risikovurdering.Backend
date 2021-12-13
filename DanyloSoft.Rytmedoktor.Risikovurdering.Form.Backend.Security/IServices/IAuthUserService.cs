namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public interface IAuthUserService
  {
    AuthUser Login(string username, string hashedPassword);
  }
}