using System;
using System.Collections.Generic;
using System.IO;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services;
using Moq;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Test.
  Services_Test
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

    [Fact]
    public void GetQuestionById_ProvidedWithId_ReturnsQuestions()
    {
      var expectedQuestion = new FormQuestion();
      int mockId = 1;
      _mock.Setup(r => r.FindQuestionById(mockId))
        .Returns(expectedQuestion);
      Assert.Equal(expectedQuestion, _service.GetQuestionById(mockId));
    }

    [Fact]
    public void GetQuestionById_ProvidedWithIdZero_ThrowsArgumentExceptionError()
    {
      Assert.Throws<ArgumentException>(() =>
      {
        _service.GetQuestionById(0);
      });
    }

    [Fact]
    public void GetQuestionById_ProvidedWithIdZero_ThrowsMessage()
    {
      var exception = Assert.Throws<ArgumentException>(() =>
      {
        _service.GetQuestionById(0);
      });
      var expectedMessage = "Id provided cannot be equal to 0";
      Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void CreateQuestion_ProvidedWithFormQuestion_ReturnsQuestion()
    {
      var expectedQuestion = new FormQuestion();
      _mock.Setup(r => r.CreateQuestion(expectedQuestion))
        .Returns(expectedQuestion);
      Assert.Equal(expectedQuestion, _service.CreateQuestion(expectedQuestion));
      _mock.Verify(r => r.CreateQuestion(expectedQuestion), Times.Once);
    }

    [Fact]
    public void UpdateQuestion_ProvidedWithFormQuestion_ReturnsQuestion()
    {
      var expectedQuestion = new FormQuestion();
      _mock.Setup(r => r.UpdateQuestion(expectedQuestion))
        .Returns(expectedQuestion);
      Assert.Equal(expectedQuestion, _service.UpdateQuestion(expectedQuestion));
    }

    [Fact]
    public void UpdateQuestion_CallsDatabase_Once()
    {
      //todo amount of times called check on all methods
      var expectedQuestion = new FormQuestion();
      _service.UpdateQuestion(expectedQuestion);
      _mock.Verify(r => r.UpdateQuestion(expectedQuestion), Times.Once);
    }

    [Fact]
    public void DeleteQuestion_ProvidedWithId_ReturnsDeletedQuestion()
    {
      var expectedQuestion = new FormQuestion();
      var id = 9;
      _mock.Setup(r => r.DeleteQuestion(id))
        .Returns(expectedQuestion);
      Assert.Equal(expectedQuestion, _service.DeleteQuestion(id));
    }
    
    [Fact]
    public void DeleteQuestion_CallsDatabase_Once()
    {
      //todo amount of times called check on all methods
      var expectedQuestion = new FormQuestion();
      var id = 9;
      _service.DeleteQuestion(id);
      _mock.Verify(r => r.DeleteQuestion(id), Times.Once);
    }
  }
}