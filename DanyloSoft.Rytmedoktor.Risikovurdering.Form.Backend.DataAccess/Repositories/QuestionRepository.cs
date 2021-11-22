using System.Collections.Generic;
using System.IO;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Repositories
{
  public class QuestionRepository : IQuestionRepository 
  {
    private readonly MainDbContext _ctx;

    public QuestionRepository(MainDbContext ctx)
    {
      if (ctx == null)
      {
        throw new InvalidDataException("DbContext cannot be null");
      }
      _ctx = ctx;
    }
    
    public List<FormQuestion> FindAllQuestions()
    {
      _ctx.FormQuestions.
    }
  }
}