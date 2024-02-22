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
            var addedEmployee = await _employeeManager.AddAsync(request);
            return Ok(addedEmployee);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteEmployeeRequest request)
        {

            
            return Ok(await _employeeManager.DeleteAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetByIdEmployeeRequest request)
        {
            var user = await _employeeManager.GetByIdAsync(request);
            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _employeeManager.GetAllAsync();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateEmployeeRequest request)
        {
            return Ok(await _employeeManager.UpdateAsync(request));
        }
    }
}
