using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstracts;
using Business.Requests.User;
using Business.Requests.Applicant;
using Microsoft.AspNetCore.Authorization;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : BaseController
    {
        private readonly IApplicantService _applicantManager;

        public ApplicantController(IApplicantService applicantManager)
        {
            _applicantManager = applicantManager;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateApplicantRequest request)
        {
            return HandleDataResult(await _applicantManager.AddAsync(request));
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(DeleteApplicantRequest request)
        {
            return HandleResult(await _applicantManager.DeleteAsync(request));
        }

        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(GetByIdApplicantRequest request)
        {
            var user = await _applicantManager.GetByIdAsync(request);
            return HandleDataResult(user);
        }

        //[Authorize(Roles = "Applicant.List")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _applicantManager.GetAllAsync();
            return HandleDataResult(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateApplicantRequest request)
        {
            return HandleDataResult(await _applicantManager.UpdateAsync(request));
        }
    }
}
