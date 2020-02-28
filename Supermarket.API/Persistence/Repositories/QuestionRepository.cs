using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class QuestionRepository : BaseRepository, IQuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
            //  Empty implementation
        }

        public async Task<IEnumerable<Question>> ListAsync()
        {
            return await context.Questions.Include(q => q.Options)
                                          .ToListAsync();
        }

        public async Task AddAsync(Question question)
        {
            await context.Questions.AddAsync(question);
        }

        public async Task<Question> FindByIdAsync(int id)
        {
            return await context.Questions.FindAsync(id);
        }

        public async Task<Question> FindRandomAsync() =>
            await context.Questions.OrderBy(o => Guid.NewGuid()).FirstAsync();

        public void Update(Question question)
        {
            context.Questions.Update(question);
        }

        public void Remove(Question question)
        {
            context.Questions.Remove(question);
        }
    }
}
