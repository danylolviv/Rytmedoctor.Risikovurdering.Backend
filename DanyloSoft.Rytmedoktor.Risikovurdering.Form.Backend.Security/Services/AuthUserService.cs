namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public class AuthUserService : IAuthUserService
  {
    private readonly IUserRepository _userRepo;

    public AuthUserService(IUserRepository userRepo)
    {
      _userRepo = userRepo;
    }
    
    public AuthUser GetUser(string username)
    {
      return _userRepo.FindUser(username);
    }
  }
}