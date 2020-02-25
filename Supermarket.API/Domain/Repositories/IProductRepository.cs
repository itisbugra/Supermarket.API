using Supermarket.API.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
