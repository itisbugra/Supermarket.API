using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> ListAsync();

        Task<Question> ShowAsync(int id);

        Task<Question> SaveAsync(Question question);

        Task<Question> UpdateAsync(Question question);

        Task<Question> DeleteAsync(Question question);
    }
}
