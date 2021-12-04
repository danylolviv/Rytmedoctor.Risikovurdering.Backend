using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Test.Models.Test
{
  public class FormQuestionTest
  {
    private FormQuestion _formQuestion = new FormQuestion();

    public FormQuestionTest()
    {
      var listOptions = new List<FormAnswerOption>()
      {
        new FormAnswerOption() {Id = 1}
      };
      _formQuestion.AnswerOptions = listOptions;
    }
    
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

    [Fact]
    public void FormQuestion_AnswerOptionsField_IsAvailable()
    {
      Assert.NotNull(_formQuestion.AnswerOptions);
    }

    [Fact]
    public void FormQuestion_AnswerOptionsField_IsOfTypeListAnswOpt()
    {
      Assert.True(_formQuestion.AnswerOptions.GetType() == typeof(List<FormAnswerOption>));
    }
  }
}