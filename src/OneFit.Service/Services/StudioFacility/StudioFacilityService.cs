using AutoMapper;
using OneFit.DataAccess.Repositories.StudioFacilities;
using OneFit.Service.DTOs.StudioFacilities;
using OneFit.Service.Exceptions;

namespace OneFit.Service.Services.StudioFacility;

public class StudioFacilityService:IStudioFacilityService
{
    private readonly IStudioFacilityRepository _repository;
    private readonly IMapper _mapper;

    public StudioFacilityService(IStudioFacilityRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<StudioFacilityViewModel> CreateAsync(StudioFacilityCreateModel studioFacilityCreateModel)
    {
        var existStudioFacilityViewModel = (await _repository.SelectAllAsync())
                                            .FirstOrDefault(f => 
                                            f.FacilityId == studioFacilityCreateModel.FacilityId &&
                                            f.StudioId == studioFacilityCreateModel.StudioId);
        if (existStudioFacilityViewModel is not null)
            throw new CustomException(403, "StudioFacility already exist");
        var createStudioFacility = await _repository
                                  .InsertAsync(this._mapper
                                  .Map<Domain.Entities.StudioFacility>(studioFacilityCreateModel));
        return this._mapper.Map<StudioFacilityViewModel>(createStudioFacility);
    }

    public async Task<StudioFacilityViewModel> UpdateAsync(long id, StudioFacilityUpdateModel studioFacilityUpdateModel)
    {
        var existStudioFacility = (await _repository
                                      .SelectAllAsync())
                                  .FirstOrDefault(s => s.Id == id)
                                  ?? throw new CustomException(404, "StudioFacility not found");
        existStudioFacility.FacilityId = studioFacilityUpdateModel.FacilityId;
        existStudioFacility.StudioId = studioFacilityUpdateModel.StudioId;
        existStudioFacility.UpdatedAt = DateTime.UtcNow;
        return this._mapper.Map<StudioFacilityViewModel>(await _repository
                           .UpdateAsync(existStudioFacility));
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existStudioFacility = (await _repository
                                  .SelectAllAsync())
                                  .FirstOrDefault(s => s.Id == id)
                                  ?? throw new CustomException(404, "StudioFacility not found");
        return await _repository.DeleteAsync(id);
    }

    public async Task<StudioFacilityViewModel> GetByIdAsync(long id)
    {
        var existStudioFacility = (await _repository
                                  .SelectAllAsync())
                                  .FirstOrDefault(s => s.Id == id)
                                  ?? throw new CustomException(404, "StudioFacility not found");
        return this._mapper.Map<StudioFacilityViewModel>(existStudioFacility);
    }

    public async Task<IEnumerable<StudioFacilityViewModel>> GetAllAsync()
    {
        return this._mapper.Map<IEnumerable<StudioFacilityViewModel>>(await _repository.SelectAllAsync());
    }
}
