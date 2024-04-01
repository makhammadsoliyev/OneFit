using Dapper;
using OneFit.DataAccess.Contexts;
using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Facilities;

public class FacilityRepository(AppDbContext context) : IFacilityRepository
{
    public async Task<bool> DeleteAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                DELETE FROM "Facilities" WHERE "Id" = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<Facility> InsertAsync(Facility facility)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO "Facilities" ("Name")
                VALUES (@Name)
                    RETURNING * ;
                """;

        await connection.ExecuteScalarAsync(sql, facility);

        return (await SelectAllAsync()).LastOrDefault();
    }

    public async Task<IEnumerable<Facility>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "Facilities";
                """;

        return await connection.QueryAsync<Facility>(sql);
    }

    public async Task<Facility> SelectByIdAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "Facilities" WHERE "Id" = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<Facility>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(Facility model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE "Facilities"
                SET "Name" = @Name,
                    "UpdatedAt" = current_timestamp
                """;

        return await connection.ExecuteAsync(sql, model) > 0;
    }
}
