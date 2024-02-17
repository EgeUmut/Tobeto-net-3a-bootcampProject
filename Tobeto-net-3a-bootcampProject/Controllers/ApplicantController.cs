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
            await _applicantManager.AddAsync(request);
            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteApplicantRequest request)
        {
            var user = await _applicantManager.GetByIdAsync(request.Id);
            if (user == null)
            {
                return NotFound();
            }

            await _applicantManager.DeleteAsync(request);
            return Ok();
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _applicantManager.GetByIdAsync(id);
            if (user.Id == 0 && user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _applicantManager.GetAll();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateApplicantRequest request)
        {
            if (request.Id == 0)
            {
                return BadRequest();
            }

            await _applicantManager.UpdateAsync(request);
            return Ok();
        }
    }
}
