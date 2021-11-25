using System.Collections.Generic;
using System.IO;
using System.Linq;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Transformers;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain;
using Microsoft.EntityFrameworkCore;

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
      // return _ctx.FormQuestions
      //   .Select(q => new FormQuestion()
      //   {
      //     Id = q.Id,
      //     Description = q.Description,
      //     Title = q.Title
      //   }).ToList();
      
      FormQuestionTransformer tr = new FormQuestionTransformer();
      var listQuestions = _ctx.FormQuestions
        .Include(t => t.Type)
        .Include(o => o.AnswerOptions)
        .Select(q => new FormQuestion
        {
          Id = q.Id,
          OrderId = q.OrderId,
          Title = q.Title,
          Description = q.Description,
          Type = new QuestionType {Id = q.Type.Id, TypeName = q.Type.TypeName},
          AnswerOptions = tr.ToListFAO(q.AnswerOptions)
        }).ToList();
      return listQuestions;
      
    }
  }
}