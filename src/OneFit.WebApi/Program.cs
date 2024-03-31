using OneFit.DataAccess.Configurations;
using OneFit.DataAccess.Contexts;
using OneFit.DataAccess.Repositories.Categories;
using OneFit.DataAccess.Repositories.Facilities;
using OneFit.DataAccess.Repositories.StudioFacilities;
using OneFit.DataAccess.Repositories.Studios;
using OneFit.DataAccess.Repositories.Users;
using OneFit.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection(nameof(DbSettings)));

builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStudioRepository, StudioRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
builder.Services.AddScoped<IStudioFacilityRepository, StudioFacilityRepository>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Init();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler();

app.Run();
