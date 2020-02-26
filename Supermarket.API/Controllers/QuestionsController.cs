using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Controllers.Forms;
using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionService questionService;
        private readonly IMapper mapper;

        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            this.questionService = questionService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<QuestionView>> ListAsync()
        {
            var questions = await questionService.ListAsync();
            var resources = mapper.Map<IEnumerable<Question>, IEnumerable<QuestionView>>(questions);

            return resources;
        }

        [HttpGet("/{id}")]
        public async Task<QuestionView> ShowAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] QuestionForm form)
        {
            throw new NotImplementedException();
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] QuestionForm form)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();

            return NoContent();
        }
    }
}
