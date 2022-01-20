using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess
{
  public class DbSeeding : IMainDbSeeding
  {
    private MainDbContext _ctx;
    private IQuestionService _questionService;

    public DbSeeding(MainDbContext ctx, IQuestionService questionService)
    {
      _ctx = ctx;
      _questionService = questionService;
    }

    public void SeedDevelopment()
    {
      
      _ctx.Database.EnsureCreated();

      #region TypesSeeding
      
      _ctx.QuestionTypes.Add(new QuestionTypeEntity{Id = 1, TypeName = "Choicebox"});
      _ctx.QuestionTypes.Add(new QuestionTypeEntity{Id = 2, TypeName = "Dropdown"});
      _ctx.QuestionTypes.Add(new QuestionTypeEntity{Id = 3, TypeName = "Multiple select"});
      
      
      #endregion
      
      #region QuestionSeeding
    
        _ctx.FormQuestions.Add(new FormQuestionEntity
        {
          Id = 4, Title = "Question1", Description = "Here is q1", TypeId = 1
        });
        _ctx.FormQuestions.Add(new FormQuestionEntity
        {
          Id = 2, Title = "Question2", Description = "Here is q22", TypeId = 2
        });
        _ctx.FormQuestions.Add(new FormQuestionEntity
        {
          Id = 3, Title = "Question3", Description = "Here is q333", TypeId = 3
        });
        _ctx.FormQuestions.Add(new FormQuestionEntity
        {
          Id = 1, Title = "New Question", Description = "New description", TypeId = 3
        });
        
    #endregion
      
    #region Options Seeding
    
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 13, QuestionId  = 4,OptionText = "Option1"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 2, QuestionId  = 4, OptionText = "Option2"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 3, QuestionId  = 4, OptionText = "Option3"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 4, QuestionId  = 4, OptionText = "Option4"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 5, QuestionId  = 2,  OptionText = "Option1"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 6, QuestionId  = 2, OptionText = "Option2"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 7, QuestionId  = 2, OptionText = "Option3"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 8, QuestionId  = 2, OptionText = "Option4"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 9, QuestionId  = 3, OptionText = "Option1"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 10, QuestionId  = 3, OptionText = "Option2"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 11, QuestionId  = 3, OptionText = "Option3"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 12, QuestionId  = 3, OptionText = "Option4"}); 
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 1, QuestionId  = 1, OptionText = "Remove Option"});
      
    #endregion
      
    _ctx.SaveChanges();
      
    }

    public void SeedProduction()
    {
     // _ctx.Database.EnsureDeleted();
      _ctx.Database.EnsureCreated();
      
      // Student production
      
      _ctx.QuestionTypes.Add(new QuestionTypeEntity{ TypeName = "Choicebox"});
      _ctx.QuestionTypes.Add(new QuestionTypeEntity{ TypeName = "Dropdown"});
      _ctx.QuestionTypes.Add(new QuestionTypeEntity{ TypeName = "Multiple select"});

      _ctx.SaveChanges();

      var listOp = new List<FormAnswerOption>();
      listOp.Add(new FormAnswerOption(){OptionText = "Remove Option"});
      
      _questionService.CreateQuestion(new FormQuestion()
      {
        Title = "New Question",
        Description = "New description",
        Type = new QuestionType(){Id = 3},
        AnswerOptions = listOp
        
      });
      
      //     _ctx.FormQuestions.Add(new FormQuestionEntity
      //     {
      //       Id = 4, Title = "Question1", Description = "Here is q1", TypeId = 1
      //     });
      //     _ctx.FormQuestions.Add(new FormQuestionEntity
      //     {
      //       Id = 2, Title = "Question2", Description = "Here is q22", TypeId = 2
      //     });
      //     _ctx.FormQuestions.Add(new FormQuestionEntity
      //     {
      //       Id = 3, Title = "Question3", Description = "Here is q333", TypeId = 3
      //     });
      //     _ctx.FormQuestions.Add(new FormQuestionEntity
      //     {
      //       Id = 1, Title = "New Question", Description = "New description", TypeId = 3
      //     });
      //     
      // #endregion
      //   
      // #region Options Seeding
      //
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 13, QuestionId  = 4,OptionText = "Option1"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 2, QuestionId  = 4, OptionText = "Option2"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 3, QuestionId  = 4, OptionText = "Option3"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 4, QuestionId  = 4, OptionText = "Option4"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 5, QuestionId  = 2,  OptionText = "Option1"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 6, QuestionId  = 2, OptionText = "Option2"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 7, QuestionId  = 2, OptionText = "Option3"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 8, QuestionId  = 2, OptionText = "Option4"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 9, QuestionId  = 3, OptionText = "Option1"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 10, QuestionId  = 3, OptionText = "Option2"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 11, QuestionId  = 3, OptionText = "Option3"});
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 12, QuestionId  = 3, OptionText = "Option4"}); 
      //   _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 1, QuestionId  = 1, OptionText = "Remove Option"});
      //   
      // #endregion
      //   
      // _ctx.SaveChanges();
    }
  }
}