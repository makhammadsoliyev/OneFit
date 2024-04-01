using Dapper;
using OneFit.DataAccess.Contexts;
using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Studios;

public class StudioRepository(AppDbContext context) : IStudioRepository
{
    public async Task<bool> DeleteAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                DELETE FROM "Studios" WHERE "Id" = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<Studio> InsertAsync(Studio studio)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO "Studios" ("Name", "Description", "Address", "Type", "CategoryId")
                VALUES (@Name, @Description, @Address, @Type, @CategoryId)
                    RETURNING * ;
                """;

        await connection.ExecuteScalarAsync(sql, studio);

        return (await SelectAllAsync()).LastOrDefault();
    }

    public async Task<IEnumerable<Studio>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "Studios";
                """;

        return await connection.QueryAsync<Studio>(sql);
    }

    public async Task<Studio> SelectByIdAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "Studios" WHERE "Id" = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<Studio>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(Studio model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE "Studios"
                SET "Name" = @Name,
                    "Description" = @Description,
                    "Address" = @Address,
                    "Type" = @Type,
                    "CategoryId" = @CategoryId,
                    "UpdatedAt" = current_timestamp;
                """;

        return await connection.ExecuteAsync(sql, model) > 0;
    }
}
