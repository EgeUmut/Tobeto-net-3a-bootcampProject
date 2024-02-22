using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstracts;
using Business.Requests.User;
using Business.Requests.Applicant;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantManager;

        public ApplicantController(IApplicantService applicantManager)
        {
            _applicantManager = applicantManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateApplicantRequest request)
        {
            return Ok(await _applicantManager.AddAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteApplicantRequest request)
        {
            return Ok(await _applicantManager.DeleteAsync(request));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(GetByIdApplicantRequest request)
        {
            var user = await _applicantManager.GetByIdAsync(request);
            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _applicantManager.GetAllAsync();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateApplicantRequest request)
        {
            return Ok(await _applicantManager.UpdateAsync(request));
        }
    }
}
