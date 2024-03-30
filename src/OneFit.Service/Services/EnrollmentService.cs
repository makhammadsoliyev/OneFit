using OneFit.Domain.Entities;
using OneFit.Service.DTOs.Enrollments;
using OneFit.Service.Exceptions;
using OneFit.Service.Interfaces;

namespace OneFit.Service.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper mapper;
        private readonly IGenericRepository<Enrollment> repository;
        private IStudioService studioService;
        private IUserService userService;


        public EnrollmentService(IMapper mapper, IGenericRepository<Enrollment> repository, IStudioService studioService, IUserService userService)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.studioService = studioService;
            this.userService = userService;
        }


        public Task<EnrolmentViewModel> CreateAsync(EnrolmentCreateModel enrollment)
        {
            var existUser = await userService.GetByIdAsync(enrollment.UserId);
            var existStudio = await studioService.GetByIdAsync(enrollment.StudioId);

            var createdEnrollment = await repository.InsertAsync(mapper.Map<Enrollment>(enrollment));
            await repository.SaveAsync();

            return mapper.Map<EnrolmentViewModel>(createdEnrollment);
        }

        public Task<EnrolmentViewModel> GetByIdAsync(long id)
        {
            var existEnrollment = await repository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Enrollment not found");
            return mapper.Map<EnrolmentViewModel>(existEnrollment);
        }

        public Task<EnrolmentViewModel> UpdateAsync(long id, EnrolmentUpdateModel enrollment)
        {
            var existUser = await userService.GetByIdAsync(enrollment.UserId);
            var existStudio = await studioService.GetByIdAsync(enrollment.StudioId);

            var existEnrollment = await repository.SelectByIdAsync(id);
       ?? throw new CustomException(404, "Enrollment not found");

            var mappedEnrollment = mapper.Map(enrollment, existEnrollment);
            var updatedEnrollment = await repository.UpdateAsync(mappedEnrollment);

            await repository.SaveAsync();

            return mapper.Map<EnrolmentViewModel>(updatedEnrollment);
        }
    }
}
