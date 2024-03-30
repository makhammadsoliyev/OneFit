using OneFit.Service.DTOs.Enrollments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneFit.Service.Interfaces
{
    public interface IEnrollmentService
    {
        Task<EnrolmentViewModel> CreateAsync(EnrolmentCreateModel enrollment);
        Task<EnrolmentViewModel> UpdateAsync(long id, EnrolmentUpdateModel enrollment);
        Task<EnrolmentViewModel> GetByIdAsync(long id);
    }
}
