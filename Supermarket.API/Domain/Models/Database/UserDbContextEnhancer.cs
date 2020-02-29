using Microsoft.EntityFrameworkCore;
using Supermarket.API.Attributes;

namespace Supermarket.API.Domain.Models.Database
{
    [Injected]
    public class UserDbContextEnhancer : IModelCreatingDbContextEnhancer
    {
        public void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<User>().HasData
            (
                new User
                {
                    Id = 100,
                }
            );
        }
    }
}
