using OneFit.Service.DTOs.Categories;

namespace OneFit.Service.Services.Categories;

public interface ICategoryService
{
    /// <summary>
    /// Create new Category 
    /// </summary>
    /// <param name="categoryCreateModel"></param>
    /// <returns></returns>
    public Task<CategoryViewModel> CreateAsync(CategoryCreateModel categoryCreateModel);
    /// <summary>
    /// Update exist Category
    /// </summary>
    /// <param name="id"></param>
    /// <param name="categoryUpdateModel"></param>
    /// <returns></returns>
    public Task<CategoryViewModel> UpdateAsync(long id, CategoryUpdateModel categoryUpdateModel);

    /// <summary>
    /// Delete exist Category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> DeleteAsync(long id);
    /// <summary>
    /// Get exist Category via ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<CategoryViewModel> GetByIdAsync(long id);
    /// <summary>
    /// Get list of exist Categories
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<CategoryViewModel>> GetAllAsync();
}
