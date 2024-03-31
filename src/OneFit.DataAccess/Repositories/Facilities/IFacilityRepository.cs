using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Facilities;

public interface IFacilityRepository
{
    Task<Facility> InsertAsync(Facility model);
    Task<Facility> SelectByIdASync(long id);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(Facility model);
    Task<IEnumerable<Facility>> SelectAllAsync();
}
