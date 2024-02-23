using Business.Abstracts;
using Business.Requests.Application;
using Business.Requests.ApplicationState;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tobeto_net_3a_bootcampProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStateController : BaseController
    {
        private readonly IApplicationStateService _applicationStateService;

        public ApplicationStateController(IApplicationStateService applicationStateService)
        {
            _applicationStateService = applicationStateService;
        }

        [HttpPost("AddAsync")]
        public async Task<IActionResult> AddAsync(CreateApplicationStateRequest request)
        {
            return HandleDataResult(await _applicationStateService.AddAsync(request));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> getAllAsync()
        {
            return HandleDataResult(await _applicationStateService.GetAllAsync());
        }

        [HttpPost("GetByIdAsync")]
        public async Task<IActionResult> getByIdAsync(GetByIdApplicationStateRequest request)
        {
            return HandleDataResult(await _applicationStateService.GetByIdAsync(request));
        }

        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync(DeleteApplicationStateRequest request)
        {
            return HandleResult(await _applicationStateService.DeleteAsync(request));
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateApplicationStateRequest request)
        {
            return HandleDataResult(await _applicationStateService.UpdateAsync(request));
        }
    }
}
