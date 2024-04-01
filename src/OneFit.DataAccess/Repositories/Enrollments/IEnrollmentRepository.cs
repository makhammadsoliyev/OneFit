using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Enrollments;

public interface IEnrollmentRepository
{
    Task<Enrollment> InsertAsync(Enrollment enrollment);
    Task<Enrollment> SelectByIdAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(Enrollment enrollment);
    Task<IEnumerable<Enrollment>> SelectAllAsync();
}
