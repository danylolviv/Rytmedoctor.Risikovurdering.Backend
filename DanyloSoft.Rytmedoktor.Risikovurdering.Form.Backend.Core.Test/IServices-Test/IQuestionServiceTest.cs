using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
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

    [Fact]
    public void GetQuestions_WithNoParams_ReturnsListOfQuestions()
    {
      var mockService = new Mock<IQuestionService>();
      var expectedList = new List<FormQuestion>();
      mockService.Setup(g => g.GetQuestions())
        .Returns(expectedList);
      var service = mockService.Object;
      Assert.Equal(expectedList, service.GetQuestions());
    }
  }
}