using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities
{
  public class UserEntity
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public List<QuestionAnswerPairEntity> ListQuAnPairs { get; set; }
  }
  
}