using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionService _service;

        public QuestionController(IQuestionService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet]
        public ActionResult<List<FormQuestion>> GetQuestions()
        {
            return _service.GetQuestions();
        }

        [HttpGet("{id}")]
        public ActionResult<FormQuestion> GetQuestionById(int id)
        {
            return _service.GetQuestionById(id);
        }

        [HttpPut("{id}")]
        public ActionResult<FormQuestion> UpdateQuestion(FormQuestion updatedQuestion)
        {
            if (updatedQuestion.Id == 1)
            {
                return _service.CreateQuestion(updatedQuestion);
            }
            
            return _service.UpdateQuestion(updatedQuestion);
        }

        [HttpDelete("{id}")]
        public ActionResult<FormQuestion> DeleteQuestion(int id)
        {
            return _service.DeleteQuestion(id);
        }
    }
}