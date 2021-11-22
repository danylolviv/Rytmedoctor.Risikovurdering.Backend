using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess
{
  public class MainDbContext: DbContext
  {
    public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
    {
      
    }

    public DbSet<FormQuestionEntity> FormQuestions { get; set; }
    public DbSet<AnswerOptionEntity> AnswerOptions { get; set; }
    public DbSet<QuestionTypeEntity> QuestionTypes { get; set; }

  }
}