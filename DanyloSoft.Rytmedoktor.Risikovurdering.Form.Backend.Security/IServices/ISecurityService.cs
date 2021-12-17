namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public interface ISecurityService
  {
    JwtToken GenerateJwtToken(string username, string password);
    string HashedPassword(byte[] userSalt, string password);
    AuthUser GenerateNewAuthUser(string username);
    byte[] GenerateSalt();
  }
}