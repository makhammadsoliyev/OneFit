using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.Categories;
using OneFit.Service.Services.Categories;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await categoryService.GetAllAsync()
            });
        }

        // GET api/<CategoriesController>/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await categoryService.GetByIdAsync(id)
            });
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CategoryCreateModel category)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await categoryService.CreateAsync(category)
            });
        }

        // PUT api/<CategoriesController>/
        [HttpPut("{id}")]
        public async Task<IActionResult> PutASync(long id, [FromBody] CategoryUpdateModel category)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await categoryService.UpdateAsync(id, category)
            });
        }

        // DELETE api/<CategoriesController>/
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await categoryService.DeleteAsync(id)
            });
        }

    }
}