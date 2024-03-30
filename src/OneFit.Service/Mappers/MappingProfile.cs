using AutoMapper;
using OneFit.Domain.Entities;
using OneFit.Service.DTOs;
using OneFit.Service.DTOs.Categories;
using OneFit.Service.DTOs.Enrollments;
using OneFit.Service.DTOs.Facilities;
using OneFit.Service.DTOs.StudioFacilities;
using OneFit.Service.DTOs.Studios;
using OneFit.Service.DTOs.Users;

namespace OneFit.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, UserUpdateModel>().ReverseMap();
            CreateMap<User, UserCreateModel>().ReverseMap();

            CreateMap<Category, CategoryCreateModel>().ReverseMap();
            CreateMap<Category, CategoryUpdateModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            CreateMap<Facility, FacilityCreateModel>().ReverseMap();
            CreateMap<Facility, FacilityUpdateModel>().ReverseMap();
            CreateMap<Facility, FacilityViewModel>().ReverseMap();

            CreateMap<Studio, StudioCreateModel>().ReverseMap();
            CreateMap<Studio, StudioUpdateModel>().ReverseMap();
            CreateMap<Studio, StudioViewModel>().ReverseMap();

            CreateMap<StudioFacility, StudioFacilityCreateModel>().ReverseMap();
            CreateMap<StudioFacility, StudioFacilityUpdateModel>().ReverseMap();
            CreateMap<StudioFacility, StudioFacilityViewModel>().ReverseMap();

            CreateMap<Enrollment, EnrollmentCreateModel>().ReverseMap();
            CreateMap<Enrollment, EnrollmentUpdateModel>().ReverseMap();
            CreateMap<Enrollment, EnrollmentViewModel>().ReverseMap();

        }
    }
}
