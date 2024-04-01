using OneFit.Service.DTOs.Facilities;

namespace OneFit.Service.Services.Facilities;

public interface IFacilityService
{
    /// <summary>
    /// Create new Facility 
    /// </summary>
    /// <param name="facility"></param>
    /// <returns></returns>
    public Task<FacilityViewModel> CreateAsync(FacilityCreateModel facility);

    /// <summary>
    /// Update exist Facility
    /// </summary>
    /// <param name="id"></param>
    /// <param name="facility"></param>
    /// <returns></returns>
    public Task<FacilityViewModel> UpdateAsync(long id,FacilityUpdateModel facility);

    /// <summary>
    /// Delete exist Facility
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> DeleteAsync(long id);

    /// <summary>
    /// Get exist Facility via Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<FacilityViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Get list of exist Facilities
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<FacilityViewModel>> GetAllAsync();

}