using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.IRepositories
{
  public interface ISurveyRepository
  {
    bool SubmitSurvey(List<QuestionAnswerPair> list, string username);
  }
}