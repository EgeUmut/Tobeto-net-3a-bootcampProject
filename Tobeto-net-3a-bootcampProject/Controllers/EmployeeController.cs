using Business.Abstracts;
using Business.Concretes;
using Business.Requests.Applicant;
using Business.Requests.Employee;
using Business.Requests.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeManager;

        public EmployeeController(IEmployeeService employeeManager)
        {
            _employeeManager = employeeManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateEmployeeRequest request)
        {
            await _employeeManager.AddAsync(request);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteEmployeeRequest request)
        {
            var user = await _employeeManager.GetByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound();
            }

            await _employeeManager.DeleteAsync(request);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _employeeManager.GetByIdAsync(id);
            if (user.Id == 0 && user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _employeeManager.GetAll();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateEmployeeRequest request)
        {
            if (request.Id == 0)
            {
                return BadRequest();
            }

            await _employeeManager.UpdateAsync(request);
            return Ok();
        }
    }
}
