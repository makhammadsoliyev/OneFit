using Dapper;
using OneFit.DataAccess.Contexts;
using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.StudioFacilities;

public class StudioFacilityRepository(AppDbContext context) : IStudioFacilityRepository
{
    public async Task<bool> DeleteAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                DELETE "StudioFacilities" WHERE "Id" = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<StudioFacility> InsertAsync(StudioFacility model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO "StudioFacilities" ("FacilityId", "StudioId")
                VALUES (@FacilityId, @StudioId);
                """;

        return await connection.ExecuteScalarAsync<StudioFacility>(sql, model);
    }

    public async Task<IEnumerable<StudioFacility>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "StudioFacilities";
                """;

        return await connection.QueryAsync<StudioFacility>(sql);
    }

    public async Task<StudioFacility> SelectByIdASync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "StudioFacilities" WHERE "Id" = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<StudioFacility>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(StudioFacility model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE "StudioFacilities"
                SET "FacilityId" = @FacilityId, 
                    "StudioId" = @StudioId,
                    "UpdatedAt" = current_timestamp
                """;

        return await connection.ExecuteAsync(sql, model) > 0;
    }
}
