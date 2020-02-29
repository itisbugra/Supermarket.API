using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Controllers.Forms;
using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Repositories;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class PoolPickHandlesController : Controller
    {
        private readonly IPoolPickHandleService poolPickHandleService;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;

        public PoolPickHandlesController(IPoolPickHandleService poolPickHandleService,
                                         IUserService userService,
                                         ICategoryService categoryService,
                                         IMapper mapper)
        {
            this.poolPickHandleService = poolPickHandleService;
            this.userService = userService;
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PoolPickHandleForm form)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            try
            {
                var user = await userService.ShowAsync(form.UserId);
                var category = await categoryService.ShowAsync(form.CategoryId);
                var handle = await poolPickHandleService.Pick(user, category, null);
                var view = mapper.Map<PoolPickHandle, PoolPickHandleView>(handle);

                return Created($"/api/categories/{handle.Question.Id}", view);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (PoolPickingException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
