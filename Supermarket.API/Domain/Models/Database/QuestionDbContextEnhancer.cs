using Microsoft.EntityFrameworkCore;
using Supermarket.API.Attributes;

namespace Supermarket.API.Domain.Models.Database
{
    [Injected]
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
                },
                new Question
                {
                    Id = 101,
                    Body = "Bu soru da başka bir soru ama sence doğru mu?",
                    MimeType = EMimeType.PlainText,
                    IsVisible = true,
                }
            );
        }
    }
}
