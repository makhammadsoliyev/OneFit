using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.Categories;
using OneFit.Service.Services.Categories;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetAllCategories()
        {
            var categories = await categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryViewModel>> GetCategoryById(long id)
        {
            try
            {
                var category = await categoryService.GetByIdAsync(id);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> AddCategory(CategoryCreateModel categoryCreate)
        {
            try
            {
                var addedCategory = await categoryService.CreateAsync(categoryCreate);
                return Ok(addedCategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryViewModel>> UpdateCategory(long id, CategoryUpdateModel categoryUpdate)
        {
            var updatedCategory = await categoryService.UpdateAsync(id, categoryUpdate);
            if (updatedCategory == null)
            {
                return NotFound("Category is not found.");
            }

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(long id)
        {
            var isDeleted = await categoryService.DeleteAsync(id);
            if (!isDeleted)
            {
                return NotFound("Category is not found.");
            }
            else
            {
                return Ok("Successfully Deleted!");
            }
        }
    }
}