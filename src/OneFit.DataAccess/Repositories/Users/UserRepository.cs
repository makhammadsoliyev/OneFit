using Dapper;
using OneFit.DataAccess.Contexts;
using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Users;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<bool> DeleteAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                DELETE Users WHERE Id = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<User> InsertAsync(User model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO Users (FirstName, LastName, Phone, Password)
                VALUES (@Title, @FirstName, @LastName, @Phone, @Password)
                """;

        return await connection.ExecuteScalarAsync<User>(sql, model);
    }

    public async Task<IEnumerable<User>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELCT * FROM Users;
                """;

        return await connection.QueryAsync<User>(sql);
    }

    public async Task<User> SelectByIdASync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELCT * FROM Users WHERE id = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<User>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(User model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE Users
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    Phone = @Phone,
                    Password = @Password,
                    UpdatedAt = current_timestamp
                """;

        return await connection.ExecuteAsync(sql, model) > 0;
    }
}
