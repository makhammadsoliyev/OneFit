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
                DELETE Studios WHERE Id = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<Studio> InsertAsync(Studio model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO Studios (Name, Description, Address, StudioType, CategoryId)
                VALUES (@Name, @Description, @Address, @StudioType, @CategoryId)
                """;

        return await connection.ExecuteScalarAsync<Studio>(sql, model);
    }

    public async Task<IEnumerable<Studio>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELCT * FROM Studios;
                """;

        return await connection.QueryAsync<Studio>(sql);
    }

    public async Task<Studio> SelectByIdASync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELCT * FROM Studios WHERE id = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<Studio>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(Studio model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE Studios
                SET Name = @Name,
                    Description = @Description,
                    Address = @Address,
                    StudioType = @StudioType,
                    CategoryId = @CategoryId
                    UpdatedAt = current_timestamp
                """;

        return await connection.ExecuteAsync(sql, model) > 0;
    }
}
