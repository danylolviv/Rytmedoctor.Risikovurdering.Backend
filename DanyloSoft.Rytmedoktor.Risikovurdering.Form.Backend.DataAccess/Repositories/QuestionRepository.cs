using System.Collections.Generic;
using System.IO;
using System.Linq;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities;
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
         if (q.Id == 1) list.Remove(q);
       }

       var orderedEn = from s in list
         orderby s.OrderId
         select s;
       
       var orderedListQuest = orderedEn.ToList();
       
       return orderedListQuest;
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

    public FormQuestion CreateQuestion(FormQuestion expectedQuestion)
    {
      var newQuestion = new FormQuestionEntity()
      {
        Title = expectedQuestion.Title,
        Description = expectedQuestion.Description,
        TypeId = expectedQuestion.Type.Id,
        AnswerOptions = expectedQuestion.AnswerOptions != null
          ? expectedQuestion.AnswerOptions.Select(ao => new AnswerOptionEntity
          {
            OptionText = ao.OptionText,
            Weight = ao.Weight
          }).ToList() : null
      };
      var createdQuestion = _ctx.FormQuestions.Add(newQuestion).Entity;
      _ctx.SaveChanges();
      return new FormQuestion() {Title = createdQuestion.Title};
    }

    public FormQuestion UpdateQuestion(FormQuestion updatedQuestion)
    {
      var oldOptions = _ctx.AnswerOptions
        .Where(op => op.QuestionId == updatedQuestion.Id)
        .Select(o => new AnswerOptionEntity()
        {
          Id = o.Id
        });
      _ctx.AnswerOptions.RemoveRange(oldOptions);
      _ctx.SaveChanges();
      //Adding the options that are needed
      var newOptions = updatedQuestion.AnswerOptions
        .Select(o => new AnswerOptionEntity()
        {
          OptionText = o.OptionText,
          Weight = o.Weight,
          QuestionId = updatedQuestion.Id
        });
      _ctx.AnswerOptions.AddRange(newOptions);
      var upQuestion = new FormQuestionEntity()
      {
        Id = updatedQuestion.Id,
        Title = updatedQuestion.Title,
        Description = updatedQuestion.Description,
        TypeId = updatedQuestion.Type.Id
      };
      _ctx.FormQuestions.Update(upQuestion);
      _ctx.SaveChanges();
      
      //retrieving updated question and returning it
      return FindQuestionById(updatedQuestion.Id);
    }

    public FormQuestion DeleteQuestion(int id)
    {
      var deletedEntity = _ctx.FormQuestions
        .Remove(new FormQuestionEntity() {Id = id}).Entity;
      var deletedModel =  new FormQuestion()
      {
        Id = deletedEntity.Id,
        Title = deletedEntity.Title
      };
      _ctx.SaveChanges();
      return deletedModel;
    }

    public bool UpdateOrder(List<FormQuestion> listQuest)
    {
      foreach (var q in listQuest)
      {
        var entity = _ctx.FormQuestions.Find(q.Id);
        entity.OrderId = q.OrderId;
      }

      _ctx.SaveChanges();
      return true;
    }
  }
}