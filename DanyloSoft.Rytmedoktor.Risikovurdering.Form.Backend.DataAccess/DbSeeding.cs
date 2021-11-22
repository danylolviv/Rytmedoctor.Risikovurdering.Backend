using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess
{
  public class DbSeeding
  {
    private MainDbContext _ctx;

    public DbSeeding(MainDbContext ctx)
    {
      _ctx = ctx;
      SeedDevelopment();
    }

    private void SeedDevelopment()
    {
      _ctx.Database.EnsureDeleted();
      _ctx.Database.EnsureCreated();

      #region TypesSeeding

      _ctx.QuestionTypes.Add(new QuestionTypeEntity{Id = 1, TypeName = "Choicebox"});
      _ctx.QuestionTypes.Add(new QuestionTypeEntity{Id = 1, TypeName = "Dropdown"});
      _ctx.QuestionTypes.Add(new QuestionTypeEntity{Id = 1, TypeName = "Multiple select"});
      

      #endregion

      #region Options Seeding

      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 1, QuestionId  = 1,Type = "Option1"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 2, QuestionId  = 1, Type = "Option2"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 3, QuestionId  = 1, Type = "Option3"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 4, QuestionId  = 1, Type = "Option4"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 1, QuestionId  = 2,  Type = "Option1"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 2, QuestionId  = 2, Type = "Option2"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 3, QuestionId  = 1, Type = "Option3"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 4, QuestionId  = 1, Type = "Option4"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 1, QuestionId  = 3, Type = "Option1"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 2, QuestionId  = 3, Type = "Option2"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 3, QuestionId  = 3, Type = "Option3"});
      _ctx.AnswerOptions.Add(new AnswerOptionEntity {Id = 4, QuestionId  = 3, Type = "Option4"});

      #endregion

      #region QuestionSeeding

      _ctx.FormQuestions.Add(new FormQuestionEntity
      {
        Id = 1, Title = "Question1", Description = "Here is q1", TypeId = 1
      });
      _ctx.FormQuestions.Add(new FormQuestionEntity
      {
        Id = 2, Title = "Question2", Description = "Here is q22", TypeId = 2
      });
      _ctx.FormQuestions.Add(new FormQuestionEntity
      {
        Id = 3, Title = "Question3", Description = "Here is q333", TypeId = 2
      }); 

      #endregion
      
     
    }
  }
}