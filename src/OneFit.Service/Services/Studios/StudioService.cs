using AutoMapper;
using OneFit.DataAccess.Repositories.Studios;
using OneFit.Service.DTOs.StudioFacilities;
using OneFit.Service.DTOs.Studios;
using OneFit.Service.Exceptions;

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
                          .FirstOrDefault(s => s.Name ==model.Name);

        if (existStudio is not null)
            throw new CustomException(403, "Studio already exist");

        var createStudio = await repository.InsertAsync(this.mapper.Map<Domain.Entities.Studio>(model));

        return this.mapper.Map<StudioViewModel>(createStudio);
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<StudioViewModel> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudioViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<StudioViewModel> UpdateAsync(long id, StudioUpdateModel model)
    {
        throw new NotImplementedException();
    }
}
