using Microsoft.AspNetCore.Mvc.ApplicationModels;
using OneFit.DataAccess.Configurations;
using OneFit.DataAccess.Contexts;
using OneFit.Service.Mappers;
using OneFit.WebApi.Extensions;
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

builder.Services.AddCustomServices();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers(options
    => options.Conventions
        .Add(new RouteTokenTransformerConvention(new RouteParameterTransformer())));

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await context.Init();

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

app.UseMiddleware<ExceptionHandlerMiddleWare>();

app.Run();
