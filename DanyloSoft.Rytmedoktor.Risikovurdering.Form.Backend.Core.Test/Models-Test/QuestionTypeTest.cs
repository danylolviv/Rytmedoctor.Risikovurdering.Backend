using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Test.Models.Test
{
  public class QuestionTypeTest
  {
    public QuestionType questionType = new QuestionType();
    
    [Fact]
    public void QuestionType_IsAvailable()
    {
      Assert.NotNull(questionType);
    }

    [Fact]
    public void QuestionType_HasFieldId()
    {
      Assert.True(questionType.Id is int);
    }

    [Fact]
    public void QuestionType_IdCanBeStored()
    {
      questionType.Id = 1;
      Assert.Equal(1, questionType.Id);
    }
    
    [Fact]
    public void QuestionType_HasFieldTypeName()
    {
      questionType.TypeName = "multipleChoice";
      Assert.True(questionType.TypeName.GetType() == typeof(string));
    }

    [Fact]
    public void QuestionType_TypeNameCanBeStored()
    {
      
      questionType.TypeName = "multipleChoice";
      
      Assert.Equal("multipleChoice", questionType.TypeName);
    }
  }
}