using OneFit.Service.DTOs.Facilities;

namespace OneFit.Service.Services.Facility;

public interface IFacilityService
{
    /// <summary>
    /// Create new Facility 
    /// </summary>
    /// <param name="facilityCreateModel"></param>
    /// <returns></returns>
    public Task<FacilityViewModel> CreateAsync(FacilityCreateModel facilityCreateModel);
    /// <summary>
    /// Update exist Facility
    /// </summary>
    /// <param name="id"></param>
    /// <param name="facilityUpdateModel"></param>
    /// <returns></returns>
    public Task<FacilityViewModel> UpdateAsync(long id,FacilityUpdateModel facilityUpdateModel);

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