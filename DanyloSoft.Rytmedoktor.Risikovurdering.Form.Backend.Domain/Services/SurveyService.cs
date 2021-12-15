using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.IRepositories;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services
{
  public class SurveyService : ISurveyService
  {
    public SurveyService(ISurveyRepository repoMockObject)
    {
      throw new System.NotImplementedException();
    }


    public bool SubmitSurvey(List<QuestionAnswerPair> providedList, string username)
    {
      throw new System.NotImplementedException();
    }
  }
}