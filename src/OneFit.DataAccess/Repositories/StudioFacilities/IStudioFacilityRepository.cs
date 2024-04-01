using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.StudioFacilities;

public interface IStudioFacilityRepository
{
    Task<StudioFacility> InsertAsync(StudioFacility studioFacility);
    Task<StudioFacility> SelectByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(StudioFacility studioFacility);
    Task<IEnumerable<StudioFacility>> SelectAllAsync();
}
