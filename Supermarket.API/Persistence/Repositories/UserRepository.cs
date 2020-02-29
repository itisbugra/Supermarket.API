using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Persistence.Contexts;
using Supermarket.API.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API.Attributes;

namespace Supermarket.API.Persistence.Repositories
{
    [Injected]
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
            //  Empty implementation
        }

        public async Task<IEnumerable<User>> ListAsync() => 
            await context.Users.ToListAsync();

        public async Task<User> FindByIdAsync(int id) =>
            await context.Users.FindOrThrowAsync(id);
    }
}
