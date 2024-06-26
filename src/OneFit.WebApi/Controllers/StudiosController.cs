﻿using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.Studios;
using OneFit.Service.Services.Studios;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudiosController(IStudioService studioService) : ControllerBase
{
    // GET: api/<StudiosController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioService.GetAllAsync()
        });
    }

    // GET api/<StudiosController>/
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioService.GetByIdAsync(id)
        });
    }

    // POST api/<StudiosController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] StudioCreateModel studio)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioService.CreateAsync(studio)
        });
    }

    // PUT api/<StudiosController>/
    [HttpPut("{id}")]
    public async Task<IActionResult> PutASync(long id, [FromBody] StudioUpdateModel studio)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioService.UpdateAsync(id, studio)
        });
    }

    // DELETE api/<StudiosController>/
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await studioService.DeleteAsync(id)
        });
    }
}
