using System.Collections.Generic;
using System.IO;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services
{
  public class QuestionService : IQuestionService
  {
    private IQuestionRepository _repo;
    public QuestionService(IQuestionRepository repo)
    {
      if (repo == null)
      {
        throw new InvalidDataException("Question repo cannot be Null");
      }
      _repo = repo;
    }

    public List<FormQuestion> GetQuestions()
    {
      return _repo.FindAllQuestions();
    }

    public FormQuestion GetQuestionById(int id)
    {
      return _repo.FindQuestionById(id);
    }
  }
}