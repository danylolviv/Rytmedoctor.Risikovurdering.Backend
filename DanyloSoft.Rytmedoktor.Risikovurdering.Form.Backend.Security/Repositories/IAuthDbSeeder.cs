namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security
{
  public interface IAuthDbSeeder
  {
    void SeedDevelopment();
    void SeedProduction();
  }
}