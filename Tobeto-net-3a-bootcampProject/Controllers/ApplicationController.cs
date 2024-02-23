using Business.Abstracts;
using Business.Requests.Application;
using Business.Responses.Application;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CreateApplicationRequest request)
        {
            return HandleDataResult(await _applicationService.AddAsync(request));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return HandleDataResult(await _applicationService.GetAllAsync());
        }

        [HttpPost("GetByIdAsync")]
        public async Task<IActionResult> getByIdAsync(GetByIdApplicationRequest request)
        {
            return HandleDataResult(await _applicationService.GetByIdAsync(request));
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(DeleteApplicationRequest request)
        {
            return HandleResult(await _applicationService.DeleteAsync(request));
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationRequest request)
        {
            return HandleDataResult(await _applicationService.UpdateAsync(request));
        }
    }
}
