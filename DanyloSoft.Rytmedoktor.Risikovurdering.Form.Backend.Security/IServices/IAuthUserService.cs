namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public interface IAuthUserService
  {
    AuthUser GetUser(string username);
  }
}