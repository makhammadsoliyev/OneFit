using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.StudioFacilities;

internal class StudioFacilityRepository : IStudioFacilityRepository
{
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<StudioFacility> InsertAsync(StudioFacility model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<StudioFacility>> SelectAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StudioFacility> SelectByIdASync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(StudioFacility model)
    {
        throw new NotImplementedException();
    }
}
