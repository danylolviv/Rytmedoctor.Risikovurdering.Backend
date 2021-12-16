using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using Xunit;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Test.Models.Test
{
  public class QuestionAnswerPairTest
  {
    private QuestionAnswerPair _questionAnswerPair = new QuestionAnswerPair();
    [Fact]
    public void QuestionAnswerPair_IsAvailable()
    {
      var qAPair = new QuestionAnswerPair();
      Assert.NotNull(qAPair);
    }

    [Fact]
    public void QuestionAnswerPair_HasField_Question()
    {
      _questionAnswerPair.Question = "Test question";
      Assert.True(_questionAnswerPair.Question is string);
    }
    
    [Fact]
    public void QuestionAnswerPair_HasField_Answer()
    {
      _questionAnswerPair.Answer = "Test answer";
      Assert.True(_questionAnswerPair.Answer is string);
    }
    
    [Fact]
    public void QuestionAnswerPair_HasField_Id()
    {
      _questionAnswerPair.Id = 1;
      Assert.True(_questionAnswerPair.Id is int);
    }
  }
}