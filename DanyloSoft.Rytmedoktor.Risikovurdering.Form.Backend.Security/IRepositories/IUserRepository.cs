namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public interface IUserRepository
  {
    AuthUser FindUser(string username);
    AuthUser SaveUser(AuthUser authUser);
  }
}