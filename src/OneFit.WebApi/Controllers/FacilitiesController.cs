using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.Facilities;
using OneFit.Service.Services.Facilities;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacilitiesController(IFacilityService facilityService) : ControllerBase
{
    // GET: api/<FacilityController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await facilityService.GetAllAsync()
        });
    }

    // GET api/<FacilityController>/5
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await facilityService.GetByIdAsync(id)
        });
    }

    // POST api/<FacilityController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] FacilityCreateModel facility)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await facilityService.CreateAsync(facility)
        });
    }

    //Put api/<FacilityController>
    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] FacilityUpdateModel facility)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await facilityService.UpdateAsync(id, facility)
        });
    }

    //Delete api/<FacilityController>
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await facilityService.DeleteAsync(id)
        });
    }
 }
    