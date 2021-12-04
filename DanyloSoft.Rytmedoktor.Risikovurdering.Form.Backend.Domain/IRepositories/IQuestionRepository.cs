using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain
{
  public interface IQuestionRepository
  {
    List<FormQuestion> FindAllQuestions();
    FormQuestion FindQuestionById(int id);
  }
}