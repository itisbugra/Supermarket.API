using Supermarket.API.Attributes;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    [Injected]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
