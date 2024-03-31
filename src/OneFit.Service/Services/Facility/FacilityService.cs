using AutoMapper;
using OneFit.DataAccess.Repositories.Facilities;
using OneFit.Service.DTOs.Facilities;
using OneFit.Service.Exceptions;

namespace OneFit.Service.Services.Facility;

public class FacilityService:IFacilityService
{
    private readonly IFacilityRepository _facilityRepository; 
    private readonly IMapper _mapper;

    public FacilityService(IFacilityRepository facilityRepository,IMapper mapper)
    {
        _facilityRepository = facilityRepository;
        _mapper = mapper;
    }
    public async Task<FacilityViewModel> CreateAsync(FacilityCreateModel facilityCreateModel)
    {
        var existFacility = (await _facilityRepository
                    .SelectAllAsync())
                    .FirstOrDefault(f => f.Name == facilityCreateModel.Name) ;
        if(existFacility is not null)
                    throw new CustomException(403,"Facility already exist");
        var createFacility = await _facilityRepository
                                    .InsertAsync(this._mapper
                                    .Map<Domain.Entities.Facility>(facilityCreateModel));
        return this._mapper.Map<FacilityViewModel>(createFacility);
    }

    public async Task<FacilityViewModel> UpdateAsync(long id,FacilityUpdateModel facilityUpdateModel)
    {
        var existFacility = (await _facilityRepository
                            .SelectAllAsync())
                            .FirstOrDefault(f => f.Id == id)
                            ??throw new CustomException(404,"Facility not found");
        existFacility.Name = facilityUpdateModel.Name;
        existFacility.UpdatedAt = DateTime.UtcNow;
        return this._mapper.Map<FacilityViewModel>(await _facilityRepository.
                            UpdateAsync(existFacility));
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existStudioFacility = await _facilityRepository.SelectByIdASync(id)
                                  ??throw new CustomException(404,"Facility not found");
        return await _facilityRepository.DeleteAsync(id);
    }

    public async Task<FacilityViewModel> GetByIdAsync(long id)
    {
        var existFacility = await _facilityRepository.SelectByIdASync(id)
                            ??throw new CustomException(404,"Facility not found");
        return this._mapper.Map<FacilityViewModel>(existFacility);
    }

    public async Task<IEnumerable<FacilityViewModel>> GetAllAsync()
    {
        var existFacilities = await _facilityRepository.SelectAllAsync();
        return this._mapper.Map<IEnumerable<FacilityViewModel>>(existFacilities);
    }
}