using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class ContextsController : Controller
    {
        private readonly IContextService contextService;

        private readonly IMapper mapper;

        public ContextsController(IContextService contextService, IMapper mapper)
        {
            this.contextService = contextService;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ContextView>> ListAsync()
        {
            var contexts = await contextService.ListAsync();
            var result = mapper.Map<IEnumerable<Context>, IEnumerable<ContextView>>(contexts);

            return result;
        }
    }
}
