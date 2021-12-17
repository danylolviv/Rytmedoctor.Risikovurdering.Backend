using System.Collections.Generic;
using System.IO;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.IRepositories;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services;
using Moq;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Test.Services_Test
{
  public class SurveyServiceTest
  {
    
    Mock<ISurveyRepository> repoMock;
    SurveyService _service;
    
    public SurveyServiceTest()
    {
      repoMock = new Mock<ISurveyRepository>();
      _service = new SurveyService(repoMock.Object);
    }
    
    [Fact]
    public void SurveyService_IsAvailable()
    {
      
      var service = new SurveyService(repoMock.Object);
      Assert.True(service is ISurveyService);
    }

    [Fact]
    public void SurveyService_WithNullSurveyRepo_ThrowsDataException()
    {
      Assert.Throws<InvalidDataException>(() =>
      {
        new SurveyService(null);
      });
    }
    
    [Fact]
    public void SurveyService_WithNullSurveyRepo_ErrorWithMessage()
    {
      var exception = Assert.Throws<InvalidDataException>(() =>
      {
        new SurveyService(null);
      });
      var expectedMessage = "Cannot create instance of service without a repository";
      Assert.Equal(expectedMessage, exception.Message);
    }

    [Fact]
    public void SubmitSurvey_CallsSubmitSurveyOnDB_OnlyOnce()
    {
      var providedList = new List<QuestionAnswerPair>();
      var username = "username";
      _service.SubmitSurvey(providedList, username);
      repoMock.Verify(r => r.SubmitSurvey(providedList, username),Times.Once);
    }
  }
}