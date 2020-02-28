using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models.Database
{
    public class OptionDbContextEnhancer : IModelCreatingDbContextEnhancer
    {
        public void OnModelCreating(ModelBuilder builder)
        {
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
        }
    }
}
