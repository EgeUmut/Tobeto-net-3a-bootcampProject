using Business.Abstracts;
using Business.Concretes;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Requests.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorManager;

        public InstructorController(IInstructorService instructorManager)
        {
            _instructorManager = instructorManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateInstructorRequest request)
        {
            await _instructorManager.AddAsync(request);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteInstructorRequest request)
        {
            var user = await _instructorManager.GetByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound();
            }

            await _instructorManager.DeleteAsync(request);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _instructorManager.GetByIdAsync(id);
            if (user.Id == 0 && user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _instructorManager.GetAll();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateInstructorRequest request)
        {
            if (request.Id == 0)
            {
                return BadRequest();
            }

            await _instructorManager.UpdateAsync(request);
            return Ok();
        }
    }
}
