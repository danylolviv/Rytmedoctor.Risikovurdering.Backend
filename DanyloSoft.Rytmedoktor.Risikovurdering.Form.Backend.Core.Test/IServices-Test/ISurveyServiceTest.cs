using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using Moq;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Test.IServices.Test
{
  public class ISurveyServiceTest
  {
    public ISurveyServiceTest()
    {
      
    }
    [Fact]
    public void ISurveyService_IsAvailable()
    {
      var surveyService = new Mock<ISurveyService>();
      Assert.NotNull(surveyService);
    }

    [Fact]
    public void
      ISurveyService_ProvidedWith_ListOfPairsAndUsername_Returnsboolean()
    {
      var expectedValue = true;
      var providedList = new List<QuestionAnswerPair>();
      var usernameStr = "username";
    }
  }

  public interface ISurveyService
  {
  }
}