using Dapper;
using OneFit.DataAccess.Contexts;
using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Enrollments;

public class EnrollmentRepository(AppDbContext context) : IEnrollmentRepository
{
    public async Task<bool> DeleteAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                DELETE FROM "Enrollments" WHERE "Id" = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<Enrollment> InsertAsync(Enrollment enrollment)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO "Enrollments" ("StudioId", "UserId")
                VALUES (@StudioId, @UserId)
                    RETURNING * ;
                """;

        await connection.ExecuteScalarAsync(sql, enrollment);

        return (await SelectAllAsync()).LastOrDefault();
    }

    public async Task<IEnumerable<Enrollment>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "Enrollments";
                """;

        return await connection.QueryAsync<Enrollment>(sql);
    }

    public async Task<Enrollment> SelectByIdAsync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELECT * FROM "Enrollments" WHERE "Id" = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<Enrollment>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(Enrollment enrollment)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE "Enrollments"
                SET "UserId" = @UserId,
                    "StudioId" = @StudioId,
                    "UpdatedAt" = current_timestamp;
                """;

        return await connection.ExecuteAsync(sql, enrollment) > 0;
    }
}
