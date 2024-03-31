using Microsoft.AspNetCore.Mvc.ApplicationModels;
using OneFit.DataAccess.Configurations;
using OneFit.DataAccess.Contexts;
using OneFit.DataAccess.Repositories.Categories;
using OneFit.DataAccess.Repositories.Facilities;
using OneFit.DataAccess.Repositories.StudioFacilities;
using OneFit.DataAccess.Repositories.Studios;
using OneFit.DataAccess.Repositories.Users;
using OneFit.Service.Mappers;
using OneFit.Service.Services.Categories;
using OneFit.Service.Services.Studios;
using OneFit.WebApi.Helpers;
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

builder.Services.AddScoped<IStudioService, StudioService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers(options
    => options.Conventions
        .Add(new RouteTokenTransformerConvention(new RouteParameterTransformer())));

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
