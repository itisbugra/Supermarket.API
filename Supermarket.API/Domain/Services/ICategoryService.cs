using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();

        Task<Category> ShowAsync(int id);

        Task<SaveCategoryResponse> SaveAsync(Category category);

        Task<SaveCategoryResponse> UpdateAsync(int id, Category category);

        Task<SaveCategoryResponse> DeleteAsync(int id);
    }
}
