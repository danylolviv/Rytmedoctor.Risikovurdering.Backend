using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using Moq;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Test.IRepositories_Test
{
  public class IQuestionRepositoryTest
  {
    [Fact]
    public void IQuestionrepository_IsAvailable()
    {
      var _mock = new Mock<IQuestionRepository>();
      Assert.NotNull(_mock);
    }
    
    [Fact]
    public void GetQuestions_WithNoParams_ReturnsListOfQuestions()
    {
      var mockRepository = new Mock<IQuestionRepository>();
      var expectedList = new List<FormQuestion>();
      mockRepository.Setup(g => g.FindAllQuestions())
        .Returns(expectedList);
      var repo = mockRepository.Object;
      Assert.Equal(expectedList, repo.FindAllQuestions());
    }
  }
}