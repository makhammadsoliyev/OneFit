using Microsoft.AspNetCore.Mvc;
using OneFit.Service.DTOs.Enrollments;
using OneFit.Service.Services.Enrollments;
using OneFit.WebApi.Models;

namespace OneFit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService enrollmentService;
        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            this.enrollmentService = enrollmentService;
        }

        // GET api/<EnrollmentsController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await enrollmentService.GetAllAsync()
            });
        }

        // GET api/<EnrollmentsController>/
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await enrollmentService.GetByIdAsync(id)
            });
        }

        // POST api/<EnrollmentsController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] EnrollmentCreateModel user)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await enrollmentService.CreateAsync(user)
            });
        }

        // DELETE api/<EnrollmentsController>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok(new Response()
            {
                StatusCode = 200,
                Message = "OK",
                Data = await enrollmentService.DeleteAsync(id)
            });
        }
    }
}
