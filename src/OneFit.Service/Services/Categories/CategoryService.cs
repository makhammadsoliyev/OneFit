using AutoMapper;
using OneFit.Service.Exceptions;
using OneFit.Service.DTOs.Categories;
using OneFit.DataAccess.Repositories.Categories;
using OneFit.Domain.Entities;

namespace OneFit.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;
    private readonly IMapper mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        this.categoryRepository = categoryRepository;
        this.mapper = mapper;
    }

    public async Task<CategoryViewModel> CreateAsync(CategoryCreateModel categoryCreateModel)
    {
        var existCategory = (await categoryRepository
                    .SelectAllAsync())
                    .FirstOrDefault(c => c.Name == categoryCreateModel.Name);

        if (existCategory is not null)
            throw new CustomException(403, "Category already exist");

        var createCategory = await categoryRepository
                                 .InsertAsync(this.mapper
                                 .Map<Category>(categoryCreateModel));

        return this.mapper.Map<CategoryViewModel>(createCategory);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existCategory = (await categoryRepository
                                 .SelectAllAsync())
                                 .FirstOrDefault(c => c.Id == id)
                                 ?? throw new CustomException(404, "Category is not found");

        return await categoryRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        return this.mapper.Map<IEnumerable<CategoryViewModel>>(await categoryRepository.SelectAllAsync());
    }

    public async Task<CategoryViewModel> GetByIdAsync(long id)
    {
        var existCategory = (await categoryRepository
                                  .SelectAllAsync())
                                  .FirstOrDefault(c => c.Id == id)
                                  ?? throw new CustomException(404, "Category is not found");

        return this.mapper.Map<CategoryViewModel>(existCategory);
    }

    public async Task<CategoryViewModel> UpdateAsync(long id, CategoryUpdateModel categoryUpdateModel)
    {
        var existCategory = (await categoryRepository
                            .SelectAllAsync())
                            .FirstOrDefault(c => c.Id == id)
                            ?? throw new CustomException(404, "Category is not found");

        existCategory.Name = categoryUpdateModel.Name;
        existCategory.UpdatedAt = DateTime.UtcNow;

        await categoryRepository.UpdateAsync(existCategory);
        
        return this.mapper.Map<CategoryViewModel>(existCategory);
    }
}
