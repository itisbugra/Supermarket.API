using Supermarket.API.Attributes;
using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API
{
    [Injected]
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public Task<Question> DeleteAsync(Question question)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Question>> ListAsync() => await questionRepository.ListAsync();

        public Task<Question> SaveAsync(Question question)
        {
            throw new System.NotImplementedException();
        }

        public Task<Question> ShowAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Question> UpdateAsync(Question question)
        {
            throw new System.NotImplementedException();
        }
    }
}
