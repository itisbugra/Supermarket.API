using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API.Domain.Repositories;

namespace Supermarket.API.Extensions
{
    public static class FindOrThrowExtension
    {
        public static async ValueTask<TEntity> FindOrThrowAsync<TEntity>(this DbSet<TEntity> dbSet,
                                                                         params object[] keyValues) 
            where TEntity : class
        {
            Contract.Requires(dbSet != null);

            var result = await dbSet.FindAsync(keyValues);

            if (result == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), keyValues);
            }

            return result;
        }

        public static TEntity FindOrThrow<TEntity>(this DbSet<TEntity> dbSet,
                                                   params object[] keyValues)
            where TEntity : class
        {
            Contract.Requires(dbSet != null);

            var result = dbSet.Find(keyValues);

            if (result == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), keyValues);
            }

            return result;
        }
    }
}
