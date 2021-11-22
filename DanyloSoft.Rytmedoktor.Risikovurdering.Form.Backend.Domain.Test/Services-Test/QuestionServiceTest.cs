using System.Collections.Generic;
using System.IO;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services;
using Moq;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Test.Services
{
  public class QuestionServiceTest
  {
    private Mock<IQuestionRepository> _mock;
    private QuestionService _service;

    public QuestionServiceTest()
    {
      _mock = new Mock<IQuestionRepository>();
      _service = new QuestionService(_mock.Object);
    }

    [Fact]
    public void QuestionService_IsAvailable()
    {
      Assert.True(_service is IQuestionService);
    }

    [Fact]
    public void QuestionService_WithNullProductRepo_TrowsException()
    {
      Assert.Throws<InvalidDataException>(
        () => new QuestionService(null)
        );
    }

    [Fact]
    public void QuestionService_WithNullProductRepo_ThrowsExceptionWithMessage()
    {
      var exception = Assert.Throws<InvalidDataException>(
        () => new QuestionService(null)
      );
      var expectedMessage = "Question repo cannot be Null";
      Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void GetQuestions_CallsProductRepoFindAll_OnlyOnce()
    {
      _service.GetQuestions();
      _mock.Verify(r => r.FindAllQuestions(), Times.Once);
    }

    [Fact]
    public void GetQuestions_NoFilter_ReturnsListOfAllQuestions()
    {
      var expectedList = new List<FormQuestion>();
      _mock.Setup(r => r.FindAllQuestions())
        .Returns(expectedList);
      Assert.Equal(expectedList, _service.GetQuestions());
    }
  }
}