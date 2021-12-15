namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess
{
  public interface IMainDbSeeding
  {
    void SeedDevelopment();
    void SeedProduction();
  }
}