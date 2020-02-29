using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Attributes;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;

namespace Supermarket.API.Persistence.Repositories
{
    [Injected]
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

        public async Task<Question> FindByIdAsync(int id) =>
            await context.Questions.FindAsync(id);

        public async Task<Question> FindRandomAsync() =>
            await context.Questions.Include(question => question.Options)
                                   .OrderBy(o => Guid.NewGuid())
                                   .FirstAsync();

        public async Task<Question> FindUntouchedRandomAsync(User user)
        {
            var result = from q in context.Questions.Include(q => q.Options)
                         join qpph in context.PoolPickHandles
                            on new { questionId = q.Id, pickerId = user.Id } 
                            equals new { questionId = qpph.QuestionId, pickerId = qpph.PickerId } 
                            into Handles
                         from m in Handles.DefaultIfEmpty()
                         where m == null
                         orderby Guid.NewGuid()
                         select q;

            return await result.FirstOrDefaultAsync();
        }

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
