using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Studios;

public class StudioRepository : IStudioRepository
{
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Studio> InsertAsync(Studio model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Studio>> SelectAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Studio> SelectByIdASync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Studio model)
    {
        throw new NotImplementedException();
    }
}
