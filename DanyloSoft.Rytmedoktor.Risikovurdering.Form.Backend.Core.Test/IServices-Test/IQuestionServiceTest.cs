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

    [Fact]
    public void GetQuestionById_ProvidedWithId_ReturnsQuestion()
    {
      var mockService = new Mock<IQuestionService>();
      var expectedObject = new FormQuestion();

      mockService.Setup(q => q.GetQuestionById(1))
        .Returns(expectedObject);
      
      var service = mockService.Object;
      Assert.Equal(expectedObject, service.GetQuestionById(1));
    }

    [Fact]
    public void CreateQuestion_ProvidedWithFormQuestion_ReturnsFormQuestion()
    {
      var mockService = new Mock<IQuestionService>();
      var expectedObject = new FormQuestion();

      mockService.Setup(q => q.CreateQuestion(expectedObject))
        .Returns(expectedObject);
      var service = mockService.Object;
      Assert.Equal(expectedObject, service.CreateQuestion(expectedObject));
    }

    [Fact]
    public void UpdateQuestion_ProvidedWithFormQuestion_ReturnsFormQuestion()
    {
      var mockService = new Mock<IQuestionService>();
      var expectedObject = new FormQuestion();
      mockService.Setup(q => q.UpdateQuestion(expectedObject))
        .Returns(expectedObject);
      var service = mockService.Object;
      Assert.Equal(expectedObject, service.UpdateQuestion(expectedObject));
    }
  }
}