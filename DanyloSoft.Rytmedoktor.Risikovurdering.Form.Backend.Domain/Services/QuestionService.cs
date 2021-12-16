using System;
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
      if (id == 0)
      {
        throw new ArgumentException("Id provided cannot be equal to 0");
      }
      return _repo.FindQuestionById(id);
    }

    public FormQuestion CreateQuestion(FormQuestion expectedObject)
    {
      var variable = expectedObject;
      
      return _repo.CreateQuestion(expectedObject);
    }

    public FormQuestion UpdateQuestion(FormQuestion updatedQuestion)
    {
      return _repo.UpdateQuestion(updatedQuestion);
    }

    public FormQuestion DeleteQuestion(int id)
    {
      return _repo.DeleteQuestion(id);
    }
  }
}