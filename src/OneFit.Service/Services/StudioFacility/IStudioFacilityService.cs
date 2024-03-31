using OneFit.Service.DTOs.StudioFacilities;

namespace OneFit.Service.Services.StudioFacility;

public interface IStudioFacilityService
{
    /// <summary>
    /// Create new StudioFacility 
    /// </summary>
    /// <param name="studioFacilityCreateModel"></param>
    /// <returns></returns>
    public Task<StudioFacilityViewModel> CreateAsync(StudioFacilityCreateModel studioFacilityCreateModel);

    /// <summary>
    /// Update exist StudioFacility
    /// </summary>
    /// <param name="id"></param>
    /// <param name="studioFacilityUpdateModel"></param>
    /// <returns></returns>
    public Task<StudioFacilityViewModel> UpdateAsync(long id,StudioFacilityUpdateModel studioFacilityUpdateModel);

    /// <summary>
    /// Delete exist StudioFacility
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> DeleteAsync(long id);
    /// <summary>
    /// Get exist StudioFacility via Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<StudioFacilityViewModel> GetByIdAsync(long id);
    /// <summary>
    /// Get list of exist StudioFacilities
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<StudioFacilityViewModel>> GetAllAsync();
}