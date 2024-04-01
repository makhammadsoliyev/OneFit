using AutoMapper;
using OneFit.Service.Exceptions;
using OneFit.Service.DTOs.Studios;
using OneFit.DataAccess.Repositories.Studios;
using OneFit.Service.Services.Categories;
using OneFit.Domain.Entities;

namespace OneFit.Service.Services.Studios;

public class StudioService(IStudioRepository repository, IMapper mapper, ICategoryService categoryService) : IStudioService
{
    public async Task<StudioViewModel> CreateAsync(StudioCreateModel studio)
    {
        await categoryService.GetByIdAsync(studio.CategoryId);

        var existStudio = (await repository.SelectAllAsync())
                          .FirstOrDefault(s => s.Name == studio.Name);

        if (existStudio is not null)
            throw new CustomException(403, "Studio already exist");

        var createdStudio = await repository.InsertAsync(mapper.Map<Studio>(studio));

        return mapper.Map<StudioViewModel>(createdStudio);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        _ = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Studio is not found");

        return await repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<StudioViewModel>> GetAllAsync()
    {
        return mapper.Map<IEnumerable<StudioViewModel>>(await repository.SelectAllAsync());
    }

    public async Task<StudioViewModel> GetByIdAsync(long id)
    {
        var existStudio = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Studio is not found");

        return mapper.Map<StudioViewModel>(existStudio);
    }

    public async Task<StudioViewModel> UpdateAsync(long id, StudioUpdateModel studio)
    {
        await categoryService.GetByIdAsync(studio.CategoryId);

        var existStudio = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Studio is not found");

        existStudio.Name = studio.Name;
        existStudio.Type = studio.Type;
        existStudio.Address = studio.Address;
        existStudio.UpdatedAt = DateTime.UtcNow;
        existStudio.CategoryId = studio.CategoryId;
        existStudio.Description = studio.Description;

        await repository.UpdateAsync(existStudio);

        return mapper.Map<StudioViewModel>(existStudio);
    }
}
