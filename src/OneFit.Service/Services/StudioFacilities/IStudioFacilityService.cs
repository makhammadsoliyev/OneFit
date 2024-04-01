using OneFit.Service.DTOs.StudioFacilities;

namespace OneFit.Service.Services.StudioFacilities;

public interface IStudioFacilityService
{
    /// <summary>
    /// Create new StudioFacility 
    /// </summary>
    /// <param name="studioFacility"></param>
    /// <returns></returns>
    public Task<StudioFacilityViewModel> CreateAsync(StudioFacilityCreateModel studioFacility);

    /// <summary>
    /// Update exist StudioFacility
    /// </summary>
    /// <param name="id"></param>
    /// <param name="studioFacility"></param>
    /// <returns></returns>
    public Task<StudioFacilityViewModel> UpdateAsync(long id,StudioFacilityUpdateModel studioFacility);

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