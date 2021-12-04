using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI.Dto
{
  public class GetQuestionsDto
  {
    public List<FormQuestion> ListQuestions { get; set; }
  }
}