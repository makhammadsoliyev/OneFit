using OneFit.Service.DTOs.Enrollments;

namespace OneFit.Service.Services.Enrollments
{
    public interface IEnrollmentService
    {
        Task<EnrollmentViewModel> CreateAsync(EnrollmentCreateModel enrollment);
        Task<bool> DeleteAsync(long id);
        Task<EnrollmentViewModel> GetByIdAsync(long id);
        Task<IEnumerable<EnrollmentViewModel>> GetAllAsync();
    }
}
