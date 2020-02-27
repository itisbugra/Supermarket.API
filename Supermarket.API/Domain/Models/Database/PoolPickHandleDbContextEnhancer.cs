using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models.Database
{
    public class PoolPickHandleDbContextEnhancer : IModelCreatingDbContextEnhancer
    {
        public void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PoolPickHandle>()
                   .ToTable("QuestionPoolPickHandles");
            builder.Entity<PoolPickHandle>()
                   .HasKey(p => p.Id);
            builder.Entity<PoolPickHandle>()
                   .Property(p => p.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();
            builder.Entity<PoolPickHandle>()
                   .Property(p => p.AvailableFor)
                   .IsRequired();
            builder.Entity<PoolPickHandle>()
                   .Property(p => p.InsertedAt)
                   .HasDefaultValueSql("getdate()")
                   .IsRequired();
            builder.Entity<PoolPickHandle>()
                   .HasOne(p => p.Question)
                   .WithMany(p => p.PoolPickHandles)
                   .HasForeignKey(p => p.QuestionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PoolPickHandle>().HasData
            (
                new PoolPickHandle
                {
                    Id = 100,
                    PickerId = 100,
                    QuestionId = 100,
                    AvailableFor = 300
                }
            );
        }
    }
}
