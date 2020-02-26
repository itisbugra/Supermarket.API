using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Question> Questions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //  Empty implementation
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Fruits and Vegetables" },
                new Category { Id = 101, Name = "Dairy" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "Apple",
                    QuantityInPackage = 1,
                    UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 101,
                    Name = "Milk",
                    QuantityInPackage = 2,
                    UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101,
                }
            );

            builder.Entity<Question>().ToTable("Questions");
            builder.Entity<Question>().HasKey(p => p.Id);
            builder.Entity<Question>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Question>().Property(p => p.Body).IsRequired();
            builder.Entity<Question>().Property(p => p.MimeType).IsRequired();
            builder.Entity<Question>().HasMany(p => p.Options).WithOne(p => p.Question).HasForeignKey(p => p.QuestionId);

            builder.Entity<Question>().HasData
            (
                new Question
                {
                    Id = 100,
                    Body = "Aşağıdakilerden hangisi yanlıştır?",
                    MimeType = EMimeType.PlainText
                }
            );

            builder.Entity<Option>().ToTable("QuestionOptions");
            builder.Entity<Option>().HasKey(p => p.Id);
            builder.Entity<Option>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Option>().Property(p => p.Body).IsRequired();
            builder.Entity<Option>().Property(p => p.MimeType).IsRequired();
        }
    }
}
