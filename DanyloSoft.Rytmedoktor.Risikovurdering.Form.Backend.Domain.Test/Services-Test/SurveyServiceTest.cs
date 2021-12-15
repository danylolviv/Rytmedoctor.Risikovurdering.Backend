using System.IO;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.IRepositories;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services;
using Moq;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Test.Services_Test
{
  public class SurveyServiceTest
  {
    public SurveyServiceTest()
    {
      
    }
    
    [Fact]
    public void SurveyService_IsAvailable()
    {
      var repoMock = new Mock<ISurveyRepository>();
      var service = new SurveyService(repoMock.Object);
      Assert.True(service is ISurveyService);
    }
    
    

    [Fact]
    public void SurveyService_WithNullSurveyRepo_ThrowsExeption()
    {
      var repoMock = new Mock<ISurveyRepository>();
      Assert.Throws<InvalidDataException>(() =>
      {
        new SurveyService(repoMock.Object);
      });
    }
    
  }
}