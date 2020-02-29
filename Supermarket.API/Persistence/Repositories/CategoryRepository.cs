using Microsoft.EntityFrameworkCore;
using Supermarket.API.Attributes;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Extensions;
using Supermarket.API.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Persistence.Repositories
{
    [Injected]
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
            //  Empty implementation
        }

        public async Task<IEnumerable<Category>> ListAsync() => 
            await context.Categories.ToListAsync();

        public async Task AddAsync(Category category) => 
            await context.Categories.AddAsync(category);

        public async Task<Category> FindByIdAsync(int id) => 
            await context.Categories.FindOrThrowAsync(id);

        public void Update(Category category) => 
            context.Categories.Update(category);

        public void Remove(Category category) => 
            context.Categories.Remove(category);
    }
}
