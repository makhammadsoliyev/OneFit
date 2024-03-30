using OneFit.Domain.Entities;

namespace OneFit.DataAccess.Repositories.Enrollments;

public interface IEnrollmentRepository
{
    Task<Enrollment> InsertAsync(Enrollment model);
    Task<Enrollment> SelectByIdASync(long id);
    Task<Enrollment> DeleteAsync(long id);
    Task<Enrollment> UpdateAsync(Enrollment model);
    Task<IEnumerable<Enrollment>> SelectAllAsync();
}
