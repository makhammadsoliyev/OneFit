using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.Facilities;
using OneFit.Service.Services.Facilities;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacilitiesController : ControllerBase
{
    private readonly IFacilityService _facilityService;

    public FacilitiesController(IFacilityService facilityService)
    {
        this._facilityService = facilityService;
    }

    // GET: api/<FacilityController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _facilityService.GetAllAsync()
        });
    }

    // GET api/<FacilityController>/5
    [HttpGet("{id:long}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _facilityService.GetByIdAsync(id)
        });
    }

    // POST api/<FacilityController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] FacilityCreateModel facilityCreation)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _facilityService.CreateAsync(facilityCreation)
        });
    }
    //Put api/<FacilityController>
    [HttpPut("{id:long}")]
    public async Task<IActionResult> PutAsync(long id,FacilityUpdateModel facilityUpdateModel)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _facilityService.UpdateAsync(id,facilityUpdateModel)
        });
    }
    //Delete api/<FacilityController>
    [HttpDelete("{id:long}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response()
        {
            StatusCode = 200,
            Message = "OK",
            Data = await _facilityService.DeleteAsync(id)
        });
    }
 }
    