using System.Collections.Generic;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models
{
  public class FormQuestion
  {
    public int Id { get; set; }
    public List<FormAnswerOption> AnswerOptions { get; set; }
  }
}