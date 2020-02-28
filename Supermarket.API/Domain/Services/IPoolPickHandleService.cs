using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Services
{
    public interface IPoolPickHandleService
    {
        /// <summary>
        /// Picks a question from the question pool, creating a new handle.
        /// </summary>
        /// <param name="user">User picking the question.</param>
        /// <param name="category">Category of the question being requested.</param>
        /// <param name="options">Additional options provided to the service.</param>
        /// <exception cref="PoolPickingException">Thrown when pick cannot succeed.</exception>
        /// <returns>Asynchronous task handler containing a handle object.</returns>
        Task<PoolPickHandle> Pick(User user, Category category, Dictionary<String, Object> options);
    }
}
