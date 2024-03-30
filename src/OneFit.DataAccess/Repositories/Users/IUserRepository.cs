using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Users;

public interface IUserRepository
{
    Task<User> InsertAsync(User model);
    Task<User> SelectByIdASync(long id);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(User model);
    Task<IEnumerable<User>> SelectAllAsync();
}
