using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.Users;
using OneFit.Service.Services.Users;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IUserService userService) : ControllerBase
{
    // GET: api/<UsersController>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.GetAllAsync()
        });
    }

    // GET api/<UsersController>/
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(long id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.GetByIdAsync(id)
        });
    }

    // POST api/<UsersController>
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserCreateModel user)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.CreateAsync(user)
        });
    }

    // PUT api/<UsersController>/
    [HttpPut("{id}")]
    public async Task<IActionResult> PutASync(long id, [FromBody] UserUpdateModel user)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.UpdateAsync(id, user)
        });
    }

    // DELETE api/<UsersController>/
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(new Response()
        {
            Message = "OK",
            StatusCode = 200,
            Data = await userService.DeleteAsync(id)
        });
    }
}
