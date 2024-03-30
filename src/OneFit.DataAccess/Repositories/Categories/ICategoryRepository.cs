using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Categories;

public interface ICategoryRepository
{
    Task<Category> InsertAsync(Category model);
    Task<Category> SelectByIdASync(long id);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(Category model);
    Task<IEnumerable<Category>> SelectAllAsync();
}
