namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities
{
  public class AnswerOptionEntity
  {
    public int Id { get; set; }
    public string Type { get; set; }
    public int QuestionId { get; set; }
    public FormQuestionEntity Question { get; set; }
  }
}