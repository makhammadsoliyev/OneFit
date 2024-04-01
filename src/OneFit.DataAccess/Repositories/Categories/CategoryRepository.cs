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
                DELETE FROM "Categories" WHERE "Id" = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<Category> InsertAsync(Category category)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO "Categories" ("Name")
                VALUES (@Name)
                    RETURNING * ;
                """;

        await connection.ExecuteScalarAsync(sql, category);

        return (await SelectAllAsync()).LastOrDefault();
    }

    public async Task<IEnumerable<Category>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "Categories";
                """;

        return await connection.QueryAsync<Category>(sql);
    }

    public async Task<Category> SelectByIdAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "Categories" WHERE "Id" = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<Category>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(Category model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE "Categories"
                SET "Name" = @Name,
                    "UpdatedAt" = current_timestamp;
                """;

        return await connection.ExecuteAsync(sql, model) > 0;
    }
}
