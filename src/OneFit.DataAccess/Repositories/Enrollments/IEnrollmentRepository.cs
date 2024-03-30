using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Enrollments;

public interface IEnrollmentRepository
{
    Task<Enrollment> InsertAsync(Enrollment model);
    Task<Enrollment> SelectByIdASync(long id);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(Enrollment model);
    Task<IEnumerable<Enrollment>> SelectAllAsync();
}
