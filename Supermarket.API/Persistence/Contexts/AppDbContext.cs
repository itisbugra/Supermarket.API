using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Database;
using System.Collections.Generic;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Context> Contexts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<PoolPickHandle> PoolPickHandles { get; set; }

        private readonly IEnumerable<IModelCreatingDbContextEnhancer> dbContextEnhancers;

        public AppDbContext(
            DbContextOptions<AppDbContext> options, 
            IEnumerable<IModelCreatingDbContextEnhancer> dbContextEnhancers
        ) : base(options)
        {
            this.dbContextEnhancers = dbContextEnhancers;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var enhancer in dbContextEnhancers)
            {
                enhancer.OnModelCreating(builder);
            }
        }
    }
}
