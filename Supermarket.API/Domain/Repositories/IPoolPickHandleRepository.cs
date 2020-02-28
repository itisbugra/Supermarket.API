using Supermarket.API.Domain.Models;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface IPoolPickHandleRepository
    {
        Task AddAsync(PoolPickHandle poolPickHandle);
    }
}
