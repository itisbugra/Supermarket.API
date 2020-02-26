using Supermarket.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> ListAsync();

        Task AddAsync(Question question);

        Task<Question> FindByIdAsync(int id);

        void Update(Question question);

        void Remove(Question question);
    }
}
