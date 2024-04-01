using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.StudioFacilities;
using OneFit.Service.Services.StudioFacilities;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudioFacilitiesController(IStudioFacilityService studioFacilityService) : ControllerBase
{
    //Get:api/<StudioFacilitiesController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioFacilityService.GetAllAsync()
        });
    }

    //Get api/<StudioFacilitiesController>
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioFacilityService.GetByIdAsync(id)
        });
    }

    //Post api/<StudioFacilitiesController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] StudioFacilityCreateModel studioFacility)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioFacilityService.CreateAsync(studioFacility)
        });
    }

    //Put api/<StudioFacilitiesController>
    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] StudioFacilityUpdateModel studioFacility)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioFacilityService.UpdateAsync(id, studioFacility)
        });
    }

    //Delete api/<StudioFacilitiesController>
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioFacilityService.DeleteAsync(id)
        });
    }
}