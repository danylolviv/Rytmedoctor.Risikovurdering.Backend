namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public interface ISecurityService
  {
    JwtToken generateJwtToken(string username, string password);
    string HashedPassword(byte[] userSalt, string password);
  }
}