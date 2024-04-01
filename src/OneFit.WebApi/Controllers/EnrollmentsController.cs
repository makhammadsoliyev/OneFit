using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.Enrollments;
using OneFit.Service.Services.Enrollments;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController(IEnrollmentService enrollmentService) : ControllerBase
    {
        // GET api/<EnrollmentsController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response()
            {
                Message = "OK",
                StatusCode = 200,
                Data = await enrollmentService.GetAllAsync()
            });
        }

        // GET api/<EnrollmentsController>/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok(new Response()
            {
                Message = "OK",
                StatusCode = 200,
                Data = await enrollmentService.GetByIdAsync(id)
            });
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EnrollmentCreateModel enrollment)
        {
            return Ok(new Response()
            {
                Message = "OK",
                StatusCode = 200,
                Data = await enrollmentService.CreateAsync(enrollment)
            });
        }

        // DELETE api/<EnrollmentsController>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(new Response()
            {
                Message = "OK",
                StatusCode = 200,
                Data = await enrollmentService.DeleteAsync(id)
            });
        }
    }
}
