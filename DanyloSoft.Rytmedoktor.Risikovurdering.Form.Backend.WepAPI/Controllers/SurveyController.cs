using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.Models;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        ISurveyService _service;
        
        public SurveyController(ISurveyService surveyService)
        {
            _service = surveyService;
        }

        [HttpPost]
        public ActionResult<bool> SubmitSurvey(PostSurveyDto postSurveyDto)
        {
            var listModel = postSurveyDto.listAnswerPairs.Select(pair =>
                new QuestionAnswerPair
                {
                    Answer = pair.answer,
                    Question = pair.question
                }).ToList();
            
            return _service.SubmitSurvey(listModel, postSurveyDto.username);
        }
    }
}