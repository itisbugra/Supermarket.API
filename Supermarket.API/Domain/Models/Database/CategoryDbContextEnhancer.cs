using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models.Database
{
    public class CategoryDbContextEnhancer : IModelCreatingDbContextEnhancer
    {
        public void OnModelCreating(ModelBuilder builder)
        {
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
        }
    }
}
