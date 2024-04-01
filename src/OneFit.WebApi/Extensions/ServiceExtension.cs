using OneFit.DataAccess.Repositories.Categories;
using OneFit.DataAccess.Repositories.Enrollments;
using OneFit.DataAccess.Repositories.Facilities;
using OneFit.DataAccess.Repositories.StudioFacilities;
using OneFit.DataAccess.Repositories.Studios;
using OneFit.DataAccess.Repositories.Users;
using OneFit.Service.Services.Categories;
using OneFit.Service.Services.Enrollments;
using OneFit.Service.Services.Facilities;
using OneFit.Service.Services.StudioFacilities;
using OneFit.Service.Services.Studios;
using OneFit.Service.Services.Users;

namespace OneFit.WebApi.Extensions;

public static class ServiceExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IStudioRepository, StudioRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IFacilityRepository, FacilityRepository>();
        services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
        services.AddScoped<IStudioFacilityRepository, StudioFacilityRepository>();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IStudioService, StudioService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFacilityService, FacilityService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
        services.AddScoped<IStudioFacilityService, StudioFacilityService>();
    }
}
