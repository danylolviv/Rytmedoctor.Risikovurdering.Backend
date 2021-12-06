using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices
{
  public interface IQuestionService
  {
    List<FormQuestion> GetQuestions();
    FormQuestion GetQuestionById(int id);
    FormQuestion CreateQuestion(FormQuestion newQuestion);
    FormQuestion UpdateQuestion(FormQuestion updatedQuestion);
  }
}