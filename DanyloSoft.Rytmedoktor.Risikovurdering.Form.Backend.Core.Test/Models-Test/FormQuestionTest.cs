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
    public void FormQuestion_AnswerOptionsField_HoldsListOptions()
    {
      var listOptions = new List<FormAnswerOption>();
      _formQuestion.AnswerOptions = listOptions;
      Assert.Equal(listOptions, _formQuestion.AnswerOptions);
    }

    [Fact]
    public void FormQuestion_Title_IsStringType()
    {
      _formQuestion.Title = "Title";
      Assert.Equal("Title", _formQuestion.Title);
    }

    [Fact]
    public void FormQuestion_OrderId_IsInt()
    {
      _formQuestion.OrderId = 1;
      Assert.Equal(1, _formQuestion.OrderId);
    }

    [Fact]
    public void FormQuestion_Description_IsString()
    {
      _formQuestion.Description = "Desc";
      Assert.Equal("Desc", _formQuestion.Description);
    }

    [Fact]
    public void FormQuestion_Type_IsOftype_Type()
    {
      var type = new QuestionType();
      _formQuestion.Type = type;
      Assert.Equal(type, _formQuestion.Type);
    }
  }
}