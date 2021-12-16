using System.Collections.Generic;
using System.Data;
using System.IO;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.IRepositories;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services
{
  public class SurveyService : ISurveyService
  {
    
    ISurveyRepository _repo;
    
    public SurveyService(ISurveyRepository surveyRepository)
    {
      _repo = surveyRepository;
      if (surveyRepository is null)
      {
        throw new InvalidDataException("Cannot create instance of service without a repository");
      }
    }


    public bool SubmitSurvey(List<QuestionAnswerPair> providedList, string username)
    {
      return _repo.SubmitSurvey(providedList, username);
    }
  }
}