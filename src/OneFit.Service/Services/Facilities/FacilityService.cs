using AutoMapper;
using OneFit.DataAccess.Repositories.Facilities;
using OneFit.Domain.Entities;
using OneFit.Service.DTOs.Facilities;
using OneFit.Service.Exceptions;

namespace OneFit.Service.Services.Facilities;

public class FacilityService(IFacilityRepository facilityRepository, IMapper mapper) : IFacilityService
{
    public async Task<FacilityViewModel> CreateAsync(FacilityCreateModel facilityCreateModel)
    {
        var existFacility = (await facilityRepository
                            .SelectAllAsync())
                            .FirstOrDefault(f => f.Name == facilityCreateModel.Name) ;
        if(existFacility is not null)
            throw new CustomException(403,"Facility already exist");

        var createdFacility = await facilityRepository.InsertAsync(mapper.Map<Facility>(facilityCreateModel));

        return mapper.Map<FacilityViewModel>(createdFacility);
    }

    public async Task<FacilityViewModel> UpdateAsync(long id,FacilityUpdateModel facilityUpdateModel)
    {
        var existFacility = await facilityRepository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Facility not found");

        existFacility.UpdatedAt = DateTime.UtcNow;
        existFacility.Name = facilityUpdateModel.Name;

        await facilityRepository.UpdateAsync(existFacility);

        return mapper.Map<FacilityViewModel>(existFacility);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        _ = await facilityRepository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Facility not found");

        return await facilityRepository.DeleteAsync(id);
    }

    public async Task<FacilityViewModel> GetByIdAsync(long id)
    {
        var facility = await facilityRepository.SelectByIdAsync(id)
            ?? throw new CustomException(404, "Facility not found");

        return mapper.Map<FacilityViewModel>(facility);
    }

    public async Task<IEnumerable<FacilityViewModel>> GetAllAsync()
    {
        var facilities = await facilityRepository.SelectAllAsync();

        return mapper.Map<IEnumerable<FacilityViewModel>>(facilities);
    }
}