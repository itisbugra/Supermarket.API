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

        Task<Question> FindRandomAsync();

        /// <summary>
        /// Returns a random question from the question pool untouched 
        /// by the user until now.
        /// </summary>
        /// <param name="user">The user to be queried against.</param>
        /// <exception cref="PoolPickingException">Thrown if no viable question was found.</exception>
        /// <returns>Random question object.</returns>
        Task<Question> FindUntouchedRandomAsync(User user);

        void Update(Question question);

        void Remove(Question question);
    }
}
