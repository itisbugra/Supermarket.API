using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    public class PoolPickHandleRepository : BaseRepository, IPoolPickHandleRepository
    {
        public PoolPickHandleRepository(AppDbContext context) : base(context)
        {
            //  Empty implementation
        }

        public async Task AddAsync(PoolPickHandle poolPickHandle)
        {
            await context.PoolPickHandles.AddAsync(poolPickHandle);
        }
    }
}
