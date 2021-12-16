using System.Collections.Generic;
using System.IO;
using System.Linq;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.IRepositories;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Repositories
{
  public class SurveyRepository : ISurveyRepository
  {
    private MainDbContext _ctx;

    public SurveyRepository(MainDbContext ctx)
    {
      if (ctx == null)
      {
        throw new InvalidDataException("DbContext cannot be null");
      }

      _ctx = ctx;
    }

    public bool SubmitSurvey(List<QuestionAnswerPair> list, string username)
    {
/*
      var newUser = _ctx.User.Add(new UserEntity()
      {
        Username = username,
        ListQuAnPairs = list != null ? list.Select(pair => new QuestionAnswerPairEntity
          {
            Answer = pair.Answer,
            Question = pair.Question,
          }
        ).ToList() : null
      });

      var newUserEntity = newUser.Entity;

      _ctx.SaveChanges();

 */
      var newUser = _ctx.User.Add(new UserEntity()
      {
        Username = username
      }).Entity;
      
      _ctx.SaveChanges();
      
      

      foreach (var pair in list)
      {
        _ctx.QuestionAnswerPair.Add(new QuestionAnswerPairEntity()
        {
          Answer = pair.Answer,
          Question = pair.Question,
          //UserId = newUser.Id,
          User = newUser
        });
      }

      _ctx.SaveChanges();

      if (newUser != null)
      {
        return true;
      }
      return false;
    }
  }
}