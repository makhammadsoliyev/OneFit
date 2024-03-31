using OneFit.Service.DTOs.Enrollments;

namespace OneFit.Service.Services.Enrollments
{
    public interface IEnrollmentService
    {
        /// <summary>
        /// Creating new enrollment
        /// </summary>
        /// <param name="enrollment"></param>
        /// <returns></returns>
        Task<EnrollmentViewModel> CreateAsync(EnrollmentCreateModel enrollment);
        
        /// <summary>
        /// Deleting exist enrollment by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(long id);
        
        /// <summary>
        /// Get exist enrollment via Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<EnrollmentViewModel> GetByIdAsync(long id);
        
        /// <summary>
        /// Get list of exist enrollments
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EnrollmentViewModel>> GetAllAsync();
    }
}