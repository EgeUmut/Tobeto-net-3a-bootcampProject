using Business.Abstracts;
using Business.Concretes;
using Business.Requests.Employee;
using Business.Requests.Instructor;
using Business.Requests.User;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : BaseController
    {
        private readonly IInstructorService _instructorManager;

        public InstructorController(IInstructorService instructorManager)
        {
            _instructorManager = instructorManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateInstructorRequest request)
        {
            
            return HandleDataResult(await _instructorManager.AddAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteInstructorRequest request)
        {
            return HandleResult(await _instructorManager.DeleteAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetByIdInstructorRequest request)
        {
            return HandleDataResult(await _instructorManager.GetByIdAsync(request));
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _instructorManager.GetAll();
            return HandleDataResult(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateInstructorRequest request)
        {
            return HandleDataResult(await _instructorManager.UpdateAsync(request));
        }
    }
}
