using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices
{
  public interface ISurveyService
  {
    bool SubmitSurvey(List<QuestionAnswerPair> providedList, string username);
  }
}