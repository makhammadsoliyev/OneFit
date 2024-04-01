using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Studios;

public interface IStudioRepository
{
    Task<Studio> InsertAsync(Studio model);
    Task<Studio> SelectByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(Studio model);
    Task<IEnumerable<Studio>> SelectAllAsync();
}
