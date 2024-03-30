namespace OneFit.DataAccess.Repositories.StudioFacilities;

public interface IStudioFacilityRepository
{
    Task<StudioFacility> InsertAsync(StudioFacility model);
    Task<StudioFacility> SelectByIdASync(long id);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(StudioFacility model);
    Task<IEnumerable<StudioFacility>> SelectAllAsync();
}
