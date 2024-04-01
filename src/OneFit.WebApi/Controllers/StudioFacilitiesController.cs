using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.StudioFacilities;
using OneFit.Service.Services.StudioFacilities;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioFacilitiesController : ControllerBase
    {
        private readonly IStudioFacilityService _studioFacilityService;

        public StudioFacilitiesController(IStudioFacilityService studioFacilityService)
        {
            _studioFacilityService = studioFacilityService;
        }

        //Get:api/<StudioFacilitiesController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _studioFacilityService.GetAllAsync()
            });
        }

        //Get api/<StudioFacilitiesController>
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _studioFacilityService.GetByIdAsync(id)
            });
        }

        //Post api/<StudioFacilitiesController>
        [HttpPost]
        public async Task<IActionResult> PostAsync(StudioFacilityCreateModel studioCreateModel)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _studioFacilityService.CreateAsync(studioCreateModel)
            });
        }

        //Put api/<StudioFacilitiesController>
        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutAsync(long id, StudioFacilityUpdateModel studioFacilityUpdateModel)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _studioFacilityService.UpdateAsync(id, studioFacilityUpdateModel)
            });
        }

        //Delete api/<StudioFacilitiesController>
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await _studioFacilityService.DeleteAsync(id)
            });
        }
    }
}
