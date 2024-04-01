using AutoMapper;
using OneFit.DataAccess.Repositories.Categories;
using OneFit.Domain.Entities;
using OneFit.Service.DTOs.Categories;
using OneFit.Service.Exceptions;

namespace OneFit.Service.Services.Categories;

public class CategoryService(IMapper mapper,
                             ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<CategoryViewModel> CreateAsync(CategoryCreateModel category)
    {
        var existCategory = (await categoryRepository
                                .SelectAllAsync())
                                .FirstOrDefault(c => c.Name == category.Name);

        if (existCategory is not null)
            throw new CustomException(403, "Category already exist");

        var createdCategory = await categoryRepository
                                 .InsertAsync(mapper
                                 .Map<Category>(category));

        return mapper.Map<CategoryViewModel>(createdCategory);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        _ = await categoryRepository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Category is not found");

        return await categoryRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        return mapper.Map<IEnumerable<CategoryViewModel>>(await categoryRepository.SelectAllAsync());
    }

    public async Task<CategoryViewModel> GetByIdAsync(long id)
    {
        var existCategory = await categoryRepository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Category is not found");

        return mapper.Map<CategoryViewModel>(existCategory);
    }

    public async Task<CategoryViewModel> UpdateAsync(long id, CategoryUpdateModel category)
    {
        var existCategory = await categoryRepository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Category is not found");

        existCategory.Name = category.Name;
        existCategory.UpdatedAt = DateTime.UtcNow;

        await categoryRepository.UpdateAsync(existCategory);
        
        return mapper.Map<CategoryViewModel>(existCategory);
    }
}
