using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API.Controllers.Forms;
using Supermarket.API.Controllers.Views;
using Supermarket.API.Domain.Models;
using Supermarket.API.Domain.Services;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers
{
    [Route("/api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        private readonly IMapper mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryView>> ListAsync()
        {
            var categories = await categoryService.ListAsync();
            var resources = mapper.Map<IEnumerable<Category>, IEnumerable<CategoryView>>(categories);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<CategoryView> ShowAsync(int id)
        {
            var category = await categoryService.ShowAsync(id);
            var resource = mapper.Map<Category, CategoryView>(category);

            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await categoryService.SaveAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = mapper.Map<Category, CategoryForm>(result.Category);

            return Created($"/api/categories/{categoryResource.Id}", categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await categoryService.UpdateAsync(id, category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = mapper.Map<Category, CategoryForm>(result.Category);

            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await categoryService.DeleteAsync(id);

            return NoContent();
        }
    }
}
