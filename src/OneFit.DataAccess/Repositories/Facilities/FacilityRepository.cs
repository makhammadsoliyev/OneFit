using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Facilities;

public class FacilityRepository : IFacilityRepository
{
    public Task<Facility> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Facility> InsertAsync(Facility model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Facility>> SelectAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Facility> SelectByIdASync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Facility> UpdateAsync(Facility model)
    {
        throw new NotImplementedException();
    }
}
