using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Test.Models.Test
{
  public class FormAnswerOptionTest
  {
    private FormAnswerOption option = new FormAnswerOption();
    [Fact]
    public void AnswerOption_IsAvailable()
    {
      Assert.NotNull(option);
    }

    [Fact]
    public void AnswerOption_IdField_MustBeAnInt()
    {
      Assert.True(option.Id is int);
    }

    [Fact]
    public void AnswerOption_IdField_StoresValue()
    {
      option.Id = 7;
      Assert.Equal(7, option.Id);
    }

    [Fact]
    public void AnswerOption_OptionText_StoresString()
    {
      option.OptionText = "The option";
      Assert.Equal("The option", option.OptionText);
    }

    [Fact]
    public void AnswerOption_Weight_StoresInt()
    {
      option.Weight = 2;
      Assert.Equal(2, option.Weight);
    }
  }
}