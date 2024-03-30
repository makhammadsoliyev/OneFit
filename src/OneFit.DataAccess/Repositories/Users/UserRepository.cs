using Dapper;
using OneFit.DataAccess.Contexts;
using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Users;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<User> InsertAsync(User model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> SelectAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> SelectByIdASync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(User model)
    {
        throw new NotImplementedException();
    }
}
