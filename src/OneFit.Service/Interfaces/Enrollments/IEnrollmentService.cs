using OneFit.Service.DTOs.Enrollments;

namespace OneFit.Service.Interfaces.Enrollments
{
    public interface IEnrollmentService
    {
        Task<EnrollmentViewModel> CreateAsync(EnrollmentCreateModel issue);
        Task<bool> DeleteAsync(long id);
        Task<EnrollmentViewModel> GetByIdAsync(long id);
        Task<IEnumerable<EnrollmentViewModel>> GetAllAsync();
    }
}
