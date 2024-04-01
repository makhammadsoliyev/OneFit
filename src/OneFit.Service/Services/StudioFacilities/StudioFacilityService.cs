using AutoMapper;
using OneFit.DataAccess.Repositories.StudioFacilities;
using OneFit.Domain.Entities;
using OneFit.Service.DTOs.StudioFacilities;
using OneFit.Service.Exceptions;
using OneFit.Service.Services.Facilities;
using OneFit.Service.Services.Studios;

namespace OneFit.Service.Services.StudioFacilities;

public class StudioFacilityService(IMapper mapper,
                                   IStudioService studioService,
                                   IFacilityService facilityService,
                                   IStudioFacilityRepository repository) : IStudioFacilityService
{
    public async Task<StudioFacilityViewModel> CreateAsync(StudioFacilityCreateModel studioFacility)
    {
        await studioService.GetByIdAsync(studioFacility.StudioId);
        await facilityService.GetByIdAsync(studioFacility.FacilityId);

        var existStudioFacility = (await repository.SelectAllAsync())
                                            .FirstOrDefault(f => 
                                            f.FacilityId == studioFacility.FacilityId &&
                                            f.StudioId == studioFacility.StudioId);
        if (existStudioFacility is not null)
            throw new CustomException(403, "StudioFacility already exist");

        var createdStudioFacility = await repository
                                  .InsertAsync(mapper.Map<StudioFacility>(studioFacility));

        return mapper.Map<StudioFacilityViewModel>(createdStudioFacility);
    }

    public async Task<StudioFacilityViewModel> UpdateAsync(long id, StudioFacilityUpdateModel studioFacility)
    {
        await studioService.GetByIdAsync(studioFacility.StudioId);
        await facilityService.GetByIdAsync(studioFacility.FacilityId);

        var existStudioFacility = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "StudioFacility not found");

        existStudioFacility.UpdatedAt = DateTime.UtcNow;
        existStudioFacility.StudioId = studioFacility.StudioId;
        existStudioFacility.FacilityId = studioFacility.FacilityId;

        await repository.UpdateAsync(existStudioFacility);

        return mapper.Map<StudioFacilityViewModel>(existStudioFacility);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        _ = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "StudioFacility not found");

        return await repository.DeleteAsync(id);
    }

    public async Task<StudioFacilityViewModel> GetByIdAsync(long id)
    {
        var existStudioFacility = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "StudioFacility not found");

        return mapper.Map<StudioFacilityViewModel>(existStudioFacility);
    }

    public async Task<IEnumerable<StudioFacilityViewModel>> GetAllAsync()
    {
        return mapper.Map<IEnumerable<StudioFacilityViewModel>>(await repository.SelectAllAsync());
    }
}
