using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API
{
    public class ContextService : IContextService
    {
        private readonly IContextRepository contextRepository;

        public ContextService(IContextRepository contextRepository)
        {
            this.contextRepository = contextRepository;
        }

        public async Task<IEnumerable<Context>> ListAsync()
        {
            return await contextRepository.ListAsync();
        }
    }
}
