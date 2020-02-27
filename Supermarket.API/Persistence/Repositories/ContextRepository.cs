using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class ContextRepository : BaseRepository, IContextRepository
    {
        public ContextRepository(AppDbContext context) : base(context)
        {
            //  Empty implementation
        }

        public async Task<IEnumerable<Context>> ListAsync()
        {
            return await context.Contexts.ToListAsync();
        }
    }
}
