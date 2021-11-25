namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities
{
  public class AnswerOptionEntity
  {
    public int Id { get; set; }
    public string OptionText { get; set; }
    public int Weight { get; set; }
    public int QuestionId { get; set; }
    public FormQuestionEntity Question { get; set; }
  }
}