using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Category> InsertAsync(Category model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> SelectAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Category> SelectByIdASync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Category model)
    {
        throw new NotImplementedException();
    }
}
