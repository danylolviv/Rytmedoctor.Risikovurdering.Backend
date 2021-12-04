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
    FormQuestionTransformer tr;

    public QuestionRepository(MainDbContext ctx)
    {
      if (ctx == null)
      {
        throw new InvalidDataException("DbContext cannot be null");
      }

      _ctx = ctx;
      tr = new FormQuestionTransformer();
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



       var list = _ctx.FormQuestions
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
       foreach (var q in list.ToList())
       {
         if (q.Id == 999) list.Remove(q);
       }
       return list;
    }

    public FormQuestion FindQuestionById(int id)
    {
      return _ctx.FormQuestions
        .Include(t => t.Type)
        .Include(o => o.AnswerOptions)
        .Select(q => new FormQuestion()
        {
          Title = q.Title,
          Description = q.Description,
          Id = q.Id,
          OrderId = q.OrderId,
          AnswerOptions = tr.ToListFAO(q.AnswerOptions),
          Type = new QuestionType {Id = q.Type.Id, TypeName = q.Type.TypeName}
        }).FirstOrDefault(q => q.Id == id);
    }
  }
}