using System.Collections.Generic;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models
{
  public class FormQuestion
  {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public QuestionType Type { get; set; }
    public List<FormAnswerOption> AnswerOptions { get; set; }
  }
}