using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Models.Database;
using System.Collections.Generic;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Context> Contexts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Question> Questions { get; set; }

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

            builder.Entity<Context>().ToTable("Contexts");
            builder.Entity<Context>().HasKey(p => p.Id);
            builder.Entity<Context>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Context>().Property(p => p.Name).IsRequired();
            builder.Entity<Context>().Property(p => p.Description).IsRequired();
            builder.Entity<Context>().Property(p => p.IsVisible).IsRequired();
            builder.Entity<Context>().Property(p => p.InsertedAt).HasDefaultValueSql("getdate()").IsRequired();

            builder.Entity<Context>().HasData
            (
                new Context
                {
                    Id = 100,
                    Name = "Scholastic Aptitude Test",
                    Description = "ational Curriculum assessment usually refers to the statutory assessments carried out in primary schools in England, colloquially known as standard attainment tests (SATs). The assessments are made up of a combination of testing and teacher assessment judgements, and are used in all government-funded primary schools in England to assess the attainment of pupils against the programmes of study of the National Curriculum at the end of Key Stages 1 and 2, when most pupils are aged 7 and 11 respectively. Until 2008, assessments were also required at the end of Key Stage 3 (14-year-olds) in secondary schools. > Source: [Wikipedia](https://en.wikipedia.org/wiki/National_Curriculum_assessment)",
                    ShortName = "SAT",
                    IsVisible = true
                }
            );

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().Property(p => p.InsertedAt).HasDefaultValueSql("getdate()").IsRequired();
            builder.Entity<Category>()
                   .HasMany(p => p.Categories)
                   .WithOne(p => p.ParentCategory)
                   .HasForeignKey(p => p.ParentCategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Mathematics" },
                new Category { Id = 101, Name = "Physics" }
            );

            builder.Entity<Category>().HasData
            (
                new Category { Id = 102, Name = "Derivatives", ParentCategoryId = 100 }
            );

            builder.Entity<Question>().ToTable("Questions");
            builder.Entity<Question>().HasKey(p => p.Id);
            builder.Entity<Question>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Question>().Property(p => p.Body).IsRequired();
            builder.Entity<Question>().Property(p => p.MimeType).IsRequired();
            builder.Entity<Question>().Property(p => p.IsVisible).IsRequired();
            builder.Entity<Question>().Property(p => p.InsertedAt).HasDefaultValueSql("getdate()").IsRequired();
            builder.Entity<Question>().HasMany(p => p.Options).WithOne(p => p.Question).HasForeignKey(p => p.QuestionId);

            builder.Entity<Question>().HasData
            (
                new Question
                {
                    Id = 100,
                    Body = "Aşağıdakilerden hangisi yanlıştır?",
                    MimeType = EMimeType.PlainText,
                    IsVisible = true,
                }
            );

            builder.Entity<Option>().ToTable("QuestionOptions");
            builder.Entity<Option>().HasKey(p => p.Id);
            builder.Entity<Option>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Option>().Property(p => p.Body).IsRequired();
            builder.Entity<Option>().Property(p => p.MimeType).IsRequired();
            builder.Entity<Option>().Property(p => p.IsCorrectOption).IsRequired();

            builder.Entity<Option>().HasData
            (
                new Option
                {
                    Id = 100,
                    Body = "Bu doğrudur mesela.",
                    MimeType = EMimeType.PlainText,
                    IsCorrectOption = true,
                    QuestionId = 100,
                },
                new Option
                {
                    Id = 101,
                    Body = "Ama bu yanlıştır.",
                    MimeType = EMimeType.PlainText,
                    IsCorrectOption = false,
                    QuestionId = 100,
                }
            );

            foreach (var enhancer in dbContextEnhancers)
            {
                enhancer.OnModelCreating(builder);
            }
        }
    }
}
