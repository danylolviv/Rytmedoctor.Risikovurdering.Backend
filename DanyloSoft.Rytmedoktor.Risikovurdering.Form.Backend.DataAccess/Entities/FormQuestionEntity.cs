using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities
{
  public class FormQuestionEntity
  {
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int TypeId { get; set; }
    public QuestionTypeEntity Type { get; set; }
    public List<AnswerOptionEntity> AnswerOptions { get; set; }
  }
}