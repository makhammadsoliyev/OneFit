using AutoMapper;
using OneFit.Service.Exceptions;
using OneFit.Service.DTOs.Studios;
using OneFit.DataAccess.Repositories.Studios;

namespace OneFit.Service.Services.Studios;

public class StudioService : IStudioService
{
    private readonly IStudioRepository repository;
    private readonly IMapper mapper;

    public StudioService(IStudioRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }
    public async Task<StudioViewModel> CreateAsync(StudioCreateModel model)
    {
        var existStudio = (await repository.SelectAllAsync())
                          .FirstOrDefault(s => s.Name == model.Name);

        if (existStudio is not null)
            throw new CustomException(403, "Studio already exist");

        var createStudio = await repository.InsertAsync(this.mapper.Map<Domain.Entities.Studio>(model));

        return this.mapper.Map<StudioViewModel>(createStudio);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existStudio = (await repository
                                .SelectAllAsync())
                                .FirstOrDefault(s => s.Id == id)
                                ?? throw new CustomException(404, "Studio is not found");

        return await repository.DeleteAsync(id);
    }

    public async Task<IEnumerable<StudioViewModel>> GetAllAsync()
    {
        return this.mapper.Map<IEnumerable<StudioViewModel>>(await repository.SelectAllAsync());
    }

    public async Task<StudioViewModel> GetByIdAsync(long id)
    {
        var existStudio = (await repository
                               .SelectAllAsync())
                               .FirstOrDefault(s => s.Id == id)
                               ?? throw new CustomException(404, "Studio is not found");

        return this.mapper.Map<StudioViewModel>(existStudio);
    }

    public async Task<StudioViewModel> UpdateAsync(long id, StudioUpdateModel model)
    {
        var existStudio = (await repository
                               .SelectAllAsync())
                               .FirstOrDefault(s => s.Id == id)
                               ?? throw new CustomException(404, "Studio is not found");

        existStudio.Name = model.Name;
        existStudio.Type = model.Type;
        existStudio.Address = model.Address;
        existStudio.UpdatedAt = DateTime.Now;
        existStudio.CategoryId = model.CategoryId;
        existStudio.Description = model.Description;

        return this.mapper.Map<StudioViewModel>(await repository.UpdateAsync(existStudio));
    }
}
