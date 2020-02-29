using Microsoft.EntityFrameworkCore;
using Supermarket.API.Attributes;

namespace Supermarket.API.Domain.Models.Database
{
    [Injected]
    public class ContextDbContextEnhancer : IModelCreatingDbContextEnhancer
    {
        public void OnModelCreating(ModelBuilder builder)
        {
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
        }
    }
}
