using System.Collections.Generic;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Entities;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Transformers
{
  public class FormQuestionTransformer
  {
    public List<FormAnswerOption> ToListFAO(List<AnswerOptionEntity> list)
    {
      List<FormAnswerOption> finalList = new List<FormAnswerOption>();
      foreach(var option in list)
      {
        finalList.Add(new FormAnswerOption()
        {
          Id = option.Id,
          OptionText = option.OptionText,
          Weight = option.Weight
        });
      }
      return finalList;
    }
  }
}