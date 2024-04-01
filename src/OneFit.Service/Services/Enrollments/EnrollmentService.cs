using AutoMapper;
using OneFit.DataAccess.Repositories.Enrollments;
using OneFit.Domain.Entities;
using OneFit.Service.DTOs.Enrollments;
using OneFit.Service.Exceptions;
using OneFit.Service.Services.Studios;
using OneFit.Service.Services.Users;

namespace OneFit.Service.Services.Enrollments;

public class EnrollmentService(IMapper mapper,
                               IStudioService studioService,
                               IEnrollmentRepository repository,
                               IUserService userService) : IEnrollmentService
{
    public async Task<EnrollmentViewModel> CreateAsync(EnrollmentCreateModel enrollment)
    {
        await userService.GetByIdAsync(enrollment.UserId);
        await studioService.GetByIdAsync(enrollment.StudioId);

        var createdEnrollment = await repository.InsertAsync(mapper.Map<Enrollment>(enrollment));

        return mapper.Map<EnrollmentViewModel>(createdEnrollment);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existEnrollment = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Enrollment not found");

        await repository.DeleteAsync(existEnrollment.Id);

        return true;
    }

    public async Task<IEnumerable<EnrollmentViewModel>> GetAllAsync()
    {
        var enrollment = await repository.SelectAllAsync();

        return mapper.Map<IEnumerable<EnrollmentViewModel>>(enrollment);
    }

    public async Task<EnrollmentViewModel> GetByIdAsync(long id)
    {
        var existEnrollment = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Enrollment not found");

        return mapper.Map<EnrollmentViewModel>(existEnrollment);
    }
}