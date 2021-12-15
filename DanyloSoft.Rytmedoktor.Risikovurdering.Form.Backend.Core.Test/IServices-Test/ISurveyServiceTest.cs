using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using Moq;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Test.IServices.Test
{
  public class ISurveyServiceTest
  {
    private Mock<ISurveyService> _serviceObject;
    public ISurveyServiceTest()
    {
      
      _serviceObject = new Mock<ISurveyService>();
    }
    [Fact]
    public void ISurveyService_IsAvailable()
    {
      var surveyService = new Mock<ISurveyService>();
      Assert.NotNull(surveyService);
    }

    [Fact]
    public void
      SubmitSurvey_ProvidedWith_ListOfPairsAndUsername_Returnsboolean()
    {
      var expectedValue = true;
      var providedList = new List<QuestionAnswerPair>();
      var username = "username";

      _serviceObject.Setup(s => s.SubmitSurvey(providedList, username))
        .Returns(expectedValue);

      var actualValue =
        _serviceObject.Object.SubmitSurvey(providedList, username);
      
      Assert.Equal(expectedValue, actualValue);
    }
  }
}