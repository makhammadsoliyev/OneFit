using OneFit.Service.DTOs.Studios;

namespace OneFit.Service.Services.Studios;

public interface IStudioService
{
    /// <summary>
    /// Create new Studio 
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public Task<StudioViewModel> CreateAsync(StudioCreateModel model);

    /// <summary>
    /// Update exist Studio
    /// </summary>
    /// <param name="id"></param>
    /// <param name="model"></param>
    /// <returns></returns>
    public Task<StudioViewModel> UpdateAsync(long id, StudioUpdateModel model);

    /// <summary>
    /// Delete exist Studio
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<bool> DeleteAsync(long id);

    /// <summary>
    /// Get exist Studio via ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<StudioViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Get list of exist Studios
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<StudioViewModel>> GetAllAsync();
}
