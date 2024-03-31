using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using OneFit.DataAccess.Configurations;
using System.Data;

namespace OneFit.DataAccess.Contexts;

public class AppDbContext(IOptions<DbSettings> dbSettings)
{
    private readonly DbSettings dbSettings = dbSettings.Value;
    public IDbConnection CreateConnection()
    {
        var connectionString = $"Host={dbSettings.Server}; Database={dbSettings.Database}; Username={dbSettings.UserId}; Password={dbSettings.Password};";
        return new NpgsqlConnection(connectionString);
    }

    public async Task Init()
    {
        await InitDatabase();
        await InitTables();
    }

    private async Task InitDatabase()
    {
        var connectionString = $"Host={dbSettings.Server}; Database=postgres; Username={dbSettings.UserId}; Password={dbSettings.Password};";
        using var connection = new NpgsqlConnection(connectionString);

        var sqlDbCount = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{dbSettings.Database}';";
        var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCount);
        if (dbCount == 0)
        {
            var sql = $"CREATE DATABASE \"{dbSettings.Database}\"";
            await connection.ExecuteAsync(sql);
        }
    }

    private async Task InitTables()
    {
        using var connection = CreateConnection();
        await _initUsers();
        await _initCategories();
        await _initStudios();
        await _initFacilities();
        await _initStudioFacilities();
        await _initEnrollments();

        async Task _initUsers()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS "Users" (
                "Id" bigserial PRIMARY KEY,
                "FirstName" varchar,
                "LastrName" varchar,
                "Phone" varchar,
                "Password" varchar
                );
                """;

            await connection.ExecuteAsync(sql);
        }

        async Task _initCategories()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS "Categories" (
                "Id" bigserial PRIMARY KEY,
                "Name" varchar,
                "CreatedAt" timestamp default current_timestamp,
                "UpdatedAt" timestamp default null
                );
                """;

            await connection.ExecuteAsync(sql);
        }

        async Task _initStudios()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS "Studios" (
                "Id" bigserial PRIMARY KEY,
                "Name" varchar,
                "Description" varchar,
                "Address" varchar,
                "Type" int,
                "CategoryId" bigint,
                "CreatedAt" timestamp default current_timestamp,
                "UpdatedAt" timestamp default null
                );
                """;

            await connection.ExecuteAsync(sql);
        }

        async Task _initFacilities()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS "Facilities" (
                "Id" bigserial PRIMARY KEY,
                "Name" varchar,
                "CreatedAt" timestamp default current_timestamp,
                "UpdatedAt" timestamp default null
                );
                """;

            await connection.ExecuteAsync(sql);
        }

        async Task _initStudioFacilities()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS "StudioFacilities" (
                "Id" bigserial PRIMARY KEY,
                "StudioId" bigint,
                "FacilityId" bigint,
                "CreatedAt" timestamp default current_timestamp,
                "UpdatedAt" timestamp default null
                );
                """;

            await connection.ExecuteAsync(sql);
        }

        async Task _initEnrollments()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS "Enrollments" (
                "Id" bigserial PRIMARY KEY,
                "StudioId" bigint,
                "UserId" bigint,
                "CreatedAt" timestamp default current_timestamp,
                "UpdatedAt" timestamp default null
                );
                """;

            await connection.ExecuteAsync(sql);
        }
    }
}
