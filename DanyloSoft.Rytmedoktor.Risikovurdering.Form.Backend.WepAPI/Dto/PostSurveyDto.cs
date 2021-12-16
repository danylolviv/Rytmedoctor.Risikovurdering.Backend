using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI.Dto
{
  public class PostSurveyDto
  {
    public string username { get; set; }
    public List<QuestionAnswerDto> listAnswerPairs { get; set; }
  }
}