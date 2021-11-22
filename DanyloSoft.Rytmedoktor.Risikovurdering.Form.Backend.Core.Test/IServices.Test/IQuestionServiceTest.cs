using Moq;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Test.IServices.Test
{
  public class IQuestionServiceTest
  {
    
    [Fact]
    public void IQuestionService_IsAvailable()
    {
      var _service = new Mock<IQuestionService>();
      Assert.NotNull(_service);
    }
  }

  public interface IQuestionService
  {
  }
}