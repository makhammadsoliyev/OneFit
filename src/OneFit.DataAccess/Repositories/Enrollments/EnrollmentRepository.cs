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
                DELETE Enrollments WHERE Id = @id;
                """;

        return await connection.ExecuteAsync(sql, new { id }) > 0;
    }

    public async Task<Enrollment> InsertAsync(Enrollment model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                INSERT INTO Enrollments (StudioId, UserId)
                VALUES (@StudioId, @UserId)
                """;

        return await connection.ExecuteScalarAsync<Enrollment>(sql, model);
    }

    public async Task<IEnumerable<Enrollment>> SelectAllAsync()
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELCT * FROM Enrollments;
                """;

        return await connection.QueryAsync<Enrollment>(sql);
    }

    public async Task<Enrollment> SelectByIdASync(long id)
    {
        using var connection = context.CreateConnection();
        var sql = """
                SELCT * FROM Enrollments WHERE id = @id;
                """;

        return await connection.QuerySingleOrDefaultAsync<Enrollment>(sql, new { id });
    }

    public async Task<bool> UpdateAsync(Enrollment model)
    {
        using var connection = context.CreateConnection();
        var sql = """
                UPDATE Enrollments
                SET UserId = @UserId,
                    StudioId = @StudioId,
                    UpdatedAt = current_timestamp
                """;

        return await connection.ExecuteAsync(sql, model) > 0;
    }
}
