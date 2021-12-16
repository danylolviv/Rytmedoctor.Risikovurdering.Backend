namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities
{
  public class QuestionAnswerPairEntity
  {
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
  }
}