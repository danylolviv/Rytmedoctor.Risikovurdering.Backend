using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Test.Models.Test
{
  public class FormQuestionTest
  {
    private FormQuestion _formQuestion = new FormQuestion();
    
    [Fact]  
    public void FormQuestion_IsAvailable()
    {
      Assert.NotNull(_formQuestion);
    }

    [Fact]
    public void FormQuestion_IdField_MustBeInt()
    {
      Assert.True(_formQuestion.Id is int);
    }

    [Fact]
    public void FormQuestion_IdField_StoresValue()
    {
      _formQuestion.Id = 3;
      Assert.Equal(3, _formQuestion.Id);
    }
  }
}