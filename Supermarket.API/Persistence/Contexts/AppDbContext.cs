using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Database;
using System.Collections.Generic;
using System.Diagnostics;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Context> Contexts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<PoolPickHandle> PoolPickHandles { get; set; }

        private readonly IConfiguration configuration;

        private readonly ILoggerFactory loggerFactory;

        private readonly IEnumerable<IModelCreatingDbContextEnhancer> dbContextEnhancers;

        public AppDbContext(
            DbContextOptions<AppDbContext> options, 
            IConfiguration configuration,
            ILoggerFactory loggerFactory,
            IEnumerable<IModelCreatingDbContextEnhancer> dbContextEnhancers
        ) : base(options)
        {
            this.configuration = configuration;
            this.loggerFactory = loggerFactory;
            this.dbContextEnhancers = dbContextEnhancers;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (Debugger.IsAttached)
            {
                //  Shouldn't log sql statements in production
                optionsBuilder
                    .UseLoggerFactory(loggerFactory);
            }

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
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
