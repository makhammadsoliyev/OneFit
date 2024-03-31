using Dapper;
using OneFit.DataAccess.Contexts;
using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Categories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<bool> DeleteAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                DELETE Categories WHERE Id = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<Category> InsertAsync(Category model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO Categories (Name)
                VALUES (@Name)
                """;

        return await connection.ExecuteScalarAsync<Category>(sql, model);
    }

    public async Task<IEnumerable<Category>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELCT * FROM Categories;
                """;

        return await connection.QueryAsync<Category>(sql);
    }

    public async Task<Category> SelectByIdASync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELCT * FROM Categories WHERE id = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<Category>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(Category model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE Categories
                SET Name = @Name,
                    UpdatedAt = current_timestamp
                """;

        return await connection.ExecuteAsync(sql, model) > 0;
    }
}
