using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models.Database
{
    public class QuestionDbContextEnhancer : IModelCreatingDbContextEnhancer
    {
        public void OnModelCreating(ModelBuilder builder)
        {
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
        }
    }
}
