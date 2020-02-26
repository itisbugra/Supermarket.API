using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            this.questionRepository = questionRepository;
        }

        public Task<QuestionView> DeleteAsync(Question question)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Question>> ListAsync() => await questionRepository.ListAsync();

        public Task<QuestionView> SaveAsync(Question question)
        {
            throw new System.NotImplementedException();
        }

        public Task<Question> ShowAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<QuestionView> UpdateAsync(Question question)
        {
            throw new System.NotImplementedException();
        }
    }
}
